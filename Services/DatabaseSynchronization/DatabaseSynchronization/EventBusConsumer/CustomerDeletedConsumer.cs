using AutoMapper;
using DatabaseSynchronization.Models;
using DatabaseSynchronization.Persistence;
using EventBus.Messages.IntegrationEvents;
using MassTransit;
using MongoDB.Driver;

namespace DatabaseSynchronization.EventBusConsumer
{
    public class CustomerDeletedConsumer : IConsumer<CustomerDeletedIntegrationEvent>
    {
        private readonly IBooksAndVideosContext _context;
        private readonly IMapper _mapper;

        public CustomerDeletedConsumer(IBooksAndVideosContext customerContext, IMapper mapper)
        {
            _context = customerContext ?? throw new ArgumentNullException(nameof(customerContext));
            _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
        }

        public async Task Consume(ConsumeContext<CustomerDeletedIntegrationEvent> context)
        {
            var customer = context.Message;

            var customerMap = _mapper.Map<CustomerDto>(customer);

            var customersCollection = _context.Customers;

            var deleteFilter = Builders<CustomerDto>.Filter.Eq(c => c.Id, customer.Id);
            await customersCollection.DeleteOneAsync(deleteFilter);
        }
    }
}
