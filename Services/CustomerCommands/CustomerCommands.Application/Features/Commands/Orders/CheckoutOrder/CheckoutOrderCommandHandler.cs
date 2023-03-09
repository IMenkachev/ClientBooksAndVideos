using AutoMapper;
using CustomerCommands.Application.Contracts.Persistence;
using CustomerCommands.Application.Features.Events.PhysicalProductsOrdered;
using CustomerCommands.Application.Models.Orders;
using CustomerCommands.Domain.Memberships;
using CustomerCommands.Domain.Orders;
using CustomerCommands.Domain.Products;
using EventBus.Messages.IntegrationEvents;
using MassTransit;
using MediatR;

namespace CustomerCommands.Application.Features.Commands.Orders.CheckoutOrder
{
    public class CheckoutOrderCommandHandler : IRequestHandler<CheckoutOrderCommand, OrderVm>
    {
        private readonly IUnitOfWork _uow;
        private readonly IMapper _mapper;
        private readonly ICheckoutOrderCommandConsistencyValidator _consistencyValidator;
        private readonly IPublisher _publisher;
        private readonly IPublishEndpoint _publishEndpoint;

        public CheckoutOrderCommandHandler(IUnitOfWork uow, IMapper mapper, ICheckoutOrderCommandConsistencyValidator consistencyValidator, IPublisher publisher, IPublishEndpoint publishEndpoint)
        {
            _uow = uow ?? throw new ArgumentNullException(nameof(uow));
            _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
            _consistencyValidator = consistencyValidator ?? throw new ArgumentNullException(nameof(consistencyValidator));
            _publisher = publisher ?? throw new ArgumentNullException(nameof(publisher));
            _publishEndpoint = publishEndpoint ?? throw new ArgumentNullException(nameof(publishEndpoint));
        }

        public async Task<OrderVm> Handle(CheckoutOrderCommand request, CancellationToken cancellationToken)
        {
            await _consistencyValidator.ValidateAsync(request);

            var productIds = request.GetProductIdsForOrder();
            var products = await _uow.Products.GetByIdAsync(productIds);

            var membershipId = request.GetMembershipIdsForOrder().SingleOrDefault();
            var membership = await _uow.Memberships.GetByIdAsync(membershipId);


            var order = MapOrder(request, products, membership);
            var orderMap = _mapper.Map<Order>(order);
            await _uow.Orders.AddAsync(orderMap);

            await UpdateCustomerPurchasesAsync(orderMap.CustomerId, products, membership);

            await _uow.SaveChangesAsync();

            var eventMessage = _mapper.Map<OrderCreatedIntegrationEvent>(orderMap);
            await _publishEndpoint.Publish(eventMessage);

            foreach (var item in orderMap.OrderItems)
            {
                await _publishEndpoint.Publish(_mapper.Map<OrderedItemsIntegrationEvent>(item));
            }

            if (products.OfType<PhysicalProduct>().Any())
            {
                await _publisher.Publish(new PhysicalProductsOrderedEvent(order.Id));
            }

            return _mapper.Map<OrderVm>(order);
        }

        private async Task UpdateCustomerPurchasesAsync(Guid customerId, ICollection<Product> products, Membership? membership)
        {
            var customer = await _uow.Customers.GetByIdAsync(customerId);

            customer.UpdateMembership(membership);

            var productsToAdd = products
                .Where(p => customer.Products.Any(cp => cp.Id == p.Id))
                .ToList();

            customer.AddProducts(productsToAdd);
            await _uow.Customers.UpdateAsync(customer);
        }

        private static Order MapOrder(
            CheckoutOrderCommand request,
            ICollection<Product> products,
            Membership? membership)
        {

            var order = new Order(
                id: Guid.NewGuid(),
                totalPrice: CalculateTotalPrice(request, products, membership),
                deliveryAddress: request.DeliveryAddress,
                purchaseDate: DateTime.Now,
                customerId: request.CustomerId
                );

            foreach (var item in request.OrderItems)
            {
                var orderItem = new OrderItem(
                    id: Guid.NewGuid(),
                    name: item!.Name!,
                    quantity: item.Quantity,
                    membershipId: item.MembershipId,
                    productId: item.ProductId
                    );

                order.OrderItems.Add(orderItem);
            }

            return order;
        }

        private static decimal CalculateTotalPrice(
            CheckoutOrderCommand request,
            ICollection<Product> products,
            Membership? membership)
        {
            decimal total = membership?.Price ?? 0;

            foreach (var item in request.OrderItems)
            {
                if (item.ProductId != null)
                {
                    var price = products.Single(p => p.Id == item.ProductId).Price;
                    total += price * (item.Quantity ?? 1);
                }
            }

            return total;
        }
    }
}
