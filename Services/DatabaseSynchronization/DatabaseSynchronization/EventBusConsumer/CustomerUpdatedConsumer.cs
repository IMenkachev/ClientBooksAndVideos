using AutoMapper;
using DatabaseSynchronization.Models;
using DatabaseSynchronization.Persistence;
using EventBus.Messages.IntegrationEvents;
using MassTransit;
using MongoDB.Driver;

namespace DatabaseSynchronization.EventBusConsumer
{
    public class CustomerUpdatedConsumer : IConsumer<CustomerUpdatedIntegrationEvent>
    {
        private readonly IBooksAndVideosContext _context;
        private readonly IMapper _mapper;

        public CustomerUpdatedConsumer(IBooksAndVideosContext customerContext, IMapper mapper)
        {
            _context = customerContext ?? throw new ArgumentNullException(nameof(customerContext));
            _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
        }

        public async Task Consume(ConsumeContext<CustomerUpdatedIntegrationEvent> context)
        {
            var customer = context.Message;

            var customerMap = _mapper.Map<CustomerDto>(customer);
            var filter = Builders<CustomerDto>.Filter.Eq(c => c.Id, customer.Id);

            var customersCollection = _context.Customers;

            await customersCollection.ReplaceOneAsync(filter, customerMap);
        }
    }
}
