using CustomerCommands.Application.Contracts.Persistence;
using CustomerCommands.Application.Exceptions;
using CustomerCommands.Application.Models.Orders;
using CustomerCommands.Domain.Customers;
using CustomerCommands.Domain.Memberships;
using CustomerCommands.Domain.Products;

namespace CustomerCommands.Application.Features.Commands.Orders.CheckoutOrder
{
    public class CheckoutOrderCommandConsistencyValidator : ICheckoutOrderCommandConsistencyValidator
    {
        private readonly IUnitOfWork _uow;

        public CheckoutOrderCommandConsistencyValidator(IUnitOfWork uow)
        {
            _uow = uow;
        }

        public async Task ValidateAsync(CheckoutOrderCommand request)
        {
            var customer = await _uow.Customers.GetByIdAsync(request.CustomerId);

            if (customer == null)
            {
                throw new NotFoundException(nameof(Customer), request.CustomerId);
            }

            var productIds = request.GetProductIdsForOrder();
            var products = await _uow.Products.GetByIdAsync(productIds);

            CheckForMissingProducts(productIds, products);
            await ValidateMembershipAsync(request, customer);
            ValidateOrderItems(request.OrderItems, products);
            ValidateDeliveryAddress(request, products);
        }

        private void ValidateDeliveryAddress(CheckoutOrderCommand request, ICollection<Product> products)
        {
            var containsPhysycalItem = products?.Any(p => p is PhysicalProduct) == true;

            if (containsPhysycalItem && string.IsNullOrWhiteSpace(request.DeliveryAddress))
            {
                throw new ValidationException(
                    nameof(request.DeliveryAddress), "Required when order contains physycal item(s)");
            }
        }

        private void ValidateOrderItems(ICollection<OrderItemDto> orderItems, ICollection<Product> products)
        {
            foreach (var item in orderItems)
            {
                if (item is null)
                {
                    throw new ValidationException(nameof(OrderItemDto), "Cannot be null");
                }

                if (item.MembershipId is null && item.ProductId is null)
                {
                    throw new ValidationException(
                        nameof(OrderItemDto), $"{nameof(item.MembershipId)} or {nameof(item.ProductId)} should have value");
                }

                else if (item.MembershipId is not null && item.ProductId is not null)
                {
                    throw new ValidationException(
                        nameof(OrderItemDto), $"Only one of {nameof(item.MembershipId)} and {nameof(item.ProductId)} should have value");
                }

                else if (item.ProductId is not null)
                {
                    var product = products.Single(p => p.Id == item.ProductId);

                    if (product is PhysicalProduct physicalProduct)
                    {
                        if (item.Quantity is null || item.Quantity < 1)
                        {
                            throw new ValidationException(nameof(OrderItemDto.Quantity),
                                "Quantity should have a valid value for physical products.");
                        }

                        if (item.Quantity > physicalProduct.Quantity)
                        {
                            throw new ValidationException(
                                nameof(OrderItemDto), $"Product with id {item.ProductId} does not have enough items to fulfill the order.");
                        }
                    }
                }
            }
        }

        private async Task ValidateMembershipAsync(CheckoutOrderCommand request, Customer customer)
        {
            var membershipIds = request.GetMembershipIdsForOrder();

            if (membershipIds.Any())
            {
                if (membershipIds.Count > 1)
                {
                    throw new ValidationException(nameof(Membership), "Only one membership can be purchased per order.");
                }

                var membershipId = membershipIds.Single();
                var membership = await _uow.Memberships.GetByIdAsync(membershipId);

                if (membership is null)
                {
                    throw new NotFoundException(nameof(Membership), membershipId);
                }

                if (customer.MembershipId == membership!.Id)
                {
                    throw new ValidationException(nameof(Membership), $"Customer already owns membership with id: {membership.Id}.");
                }
            }
        }

        private static void CheckForMissingProducts(ICollection<Guid> productIds, ICollection<Product> products)
        {
            if (productIds.Any())
            {
                var missingIds = GetMissingEntitiesIds(products, productIds);

                if (missingIds.Any())
                {
                    throw new NotFoundException(nameof(products), missingIds);
                }
            }
        }

        private static ICollection<Guid> GetMissingEntitiesIds(ICollection<Product> products, IEnumerable<Guid> ids)
        {
            if (products.Count == ids.Count())
            {
                return new List<Guid>();
            }

            ICollection<Guid> missing = new List<Guid>();

            bool isFound = false;

            foreach (var id in ids)
            {
                foreach (var product in products)
                {
                    if (id == product.Id)
                    {
                        isFound = true;
                        break;
                    }
                }

                if (!isFound)
                {
                    missing.Add(id);
                }

                isFound = false;
            }

            return missing;
        }
    }
}
