using AutoMapper;
using DatabaseSynchronization.Models;
using DatabaseSynchronization.Persistence;
using EventBus.Messages.IntegrationEvents;
using MassTransit;

namespace DatabaseSynchronization.EventBusConsumer
{
    public class OrderCreatedConsumer : IConsumer<OrderCreatedIntegrationEvent>
    {
        private readonly IBooksAndVideosContext _context;
        private readonly IMapper _mapper;

        public OrderCreatedConsumer(IBooksAndVideosContext context, IMapper mapper)
        {
            _context = context ?? throw new ArgumentNullException(nameof(context));
            _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
        }

        public async Task Consume(ConsumeContext<OrderCreatedIntegrationEvent> context)
        {
            var order = context.Message;

            var orderMap = _mapper.Map<OrderDto>(order);

            var ordersCollection = _context.Orders;

            await ordersCollection.InsertOneAsync(orderMap);
        }
    }
}
