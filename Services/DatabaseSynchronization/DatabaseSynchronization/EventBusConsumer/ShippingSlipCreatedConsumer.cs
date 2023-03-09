using AutoMapper;
using DatabaseSynchronization.Models;
using DatabaseSynchronization.Persistence;
using EventBus.Messages.IntegrationEvents;
using MassTransit;

namespace DatabaseSynchronization.EventBusConsumer
{
    public class ShippingSlipCreatedConsumer : IConsumer<ShippingSlipCreatedIntegrationEvent>
    {
        private readonly IBooksAndVideosContext _context;
        private readonly IMapper _mapper;

        public ShippingSlipCreatedConsumer(IBooksAndVideosContext context, IMapper mapper)
        {
            _context = context ?? throw new ArgumentNullException(nameof(context));
            _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
        }

        public async Task Consume(ConsumeContext<ShippingSlipCreatedIntegrationEvent> context)
        {
            var shippingSlip = context.Message;

            var shippingSlipMap = _mapper.Map<ShippingSlipDto>(shippingSlip);

            var shippingSlipCollection = _context.ShippingSlips;

            await shippingSlipCollection.InsertOneAsync(shippingSlipMap);
        }
    }
}
