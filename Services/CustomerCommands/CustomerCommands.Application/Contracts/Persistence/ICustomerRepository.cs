using CustomerCommands.Domain.Customers;

namespace CustomerCommands.Application.Contracts.Persistence
{
    public interface ICustomerRepository : IAsyncRepository<Customer>
    {
        public Task<IEnumerable<Customer>> GetAll();
    }
}
