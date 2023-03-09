using AutoMapper;
using DatabaseSynchronization.Models;
using DatabaseSynchronization.Persistence;
using EventBus.Messages.IntegrationEvents;
using MassTransit;

namespace DatabaseSynchronization.EventBusConsumer
{
    public class CustomerAddedConsumer : IConsumer<CustomerAddedIntegrationEvent>
    {
        private readonly IBooksAndVideosContext _context;
        private readonly IMapper _mapper;

        public CustomerAddedConsumer(IBooksAndVideosContext customerContext, IMapper mapper)
        {
            _context = customerContext ?? throw new ArgumentNullException(nameof(customerContext));
            _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
        }

        public async Task Consume(ConsumeContext<CustomerAddedIntegrationEvent> context)
        {
            var customer = context.Message;

            var customerMap = _mapper.Map<CustomerDto>(customer);

            var customersCollection = _context.Customers;

            await customersCollection.InsertOneAsync(customerMap);
        }
    }
}
