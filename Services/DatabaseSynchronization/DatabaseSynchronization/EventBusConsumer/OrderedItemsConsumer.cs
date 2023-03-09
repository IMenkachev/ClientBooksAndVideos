using AutoMapper;
using DatabaseSynchronization.Models;
using DatabaseSynchronization.Persistence;
using EventBus.Messages.IntegrationEvents;
using MassTransit;

namespace DatabaseSynchronization.EventBusConsumer
{
    public class OrderedItemsConsumer : IConsumer<OrderedItemsIntegrationEvent>
    {
        private readonly IBooksAndVideosContext _context;
        private readonly IMapper _mapper;

        public OrderedItemsConsumer(IBooksAndVideosContext context, IMapper mapper)
        {
            _context = context ?? throw new ArgumentNullException(nameof(context));
            _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
        }

        public async Task Consume(ConsumeContext<OrderedItemsIntegrationEvent> context)
        {
            var OrderedItem = context.Message;

            var orderedItemMap = _mapper.Map<OrderItemDto>(OrderedItem);

            var orderedItemsCollection = _context.OrderItems;

            await orderedItemsCollection.InsertOneAsync(orderedItemMap);
        }
    }
}
