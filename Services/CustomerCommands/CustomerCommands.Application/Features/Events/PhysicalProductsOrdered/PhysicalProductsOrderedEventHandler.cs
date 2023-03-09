using AutoMapper;
using CustomerCommands.Application.Contracts.Persistence;
using CustomerCommands.Domain.Products;
using CustomerCommands.Domain.ShippingSlips;
using EventBus.Messages.IntegrationEvents;
using MassTransit;
using MediatR;
using Microsoft.Extensions.Logging;

namespace CustomerCommands.Application.Features.Events.PhysicalProductsOrdered
{
    public class PhysicalProductsOrderedEventHandler : INotificationHandler<PhysicalProductsOrderedEvent>
    {
        private readonly ILogger<PhysicalProductsOrderedEventHandler> _logger;
        private readonly IUnitOfWork _uow;
        private readonly IMapper _mapper;
        private readonly IPublishEndpoint _publishEndpoint;

        public PhysicalProductsOrderedEventHandler(ILogger<PhysicalProductsOrderedEventHandler> logger, IUnitOfWork uow, IMapper mapper, IPublishEndpoint publishEndpoint)
        {
            _logger = logger ?? throw new ArgumentNullException(nameof(logger));
            _uow = uow ?? throw new ArgumentNullException(nameof(uow));
            _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
            _publishEndpoint = publishEndpoint ?? throw new ArgumentNullException(nameof(publishEndpoint));
        }

        public async Task Handle(PhysicalProductsOrderedEvent notification, CancellationToken cancellationToken)
        {
            var order = await _uow.Orders.GetByIdAsync(notification.OrderId);

            _logger.LogTrace("Start creation of shipping slip for order with id: {OrderId}", order!.Id);

            var shippingSlip = new ShippingSlip(
                id: Guid.NewGuid(),
                customerId: order.CustomerId,
                purchaseOrderId: order.Id,
                shippingAddress: order.DeliveryAddress,
                billTo: order.DeliveryAddress);

            foreach (var orderItem in order.OrderItems)
            {
                if (orderItem.Product is PhysicalProduct physicalProduct)
                {
                    shippingSlip.AddSlipItem(new ShippingSlipItem(
                        id: Guid.NewGuid(),
                        description: orderItem.Name,
                        orderQuantity: orderItem.Quantity!.Value,
                        shippedQuantity: orderItem.Quantity!.Value,
                        productId: orderItem.ProductId!.Value,
                        price: orderItem.Product.Price));

                    physicalProduct.ReduceQuantity(orderItem.Quantity.Value);
                    await _uow.Products.UpdateAsync(physicalProduct);
                }
            }

            await _uow.ShippingSlips.AddAsync(shippingSlip);
            await _uow.SaveChangesAsync();

            var shippingSlipEventMessage = _mapper.Map<ShippingSlipCreatedIntegrationEvent>(shippingSlip);
            await _publishEndpoint.Publish(shippingSlipEventMessage);

            _logger.LogTrace("Shipping slip created with id: {OrderId}", shippingSlip.Id);
        }
    }
}
