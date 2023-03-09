using CustomerQuery.API.Entities;

namespace CustomerQuery.API.Contracts
{
    public interface ICustomerRepository : IRepository<Customer>
    {
        Task<IEnumerable<Customer>> GetCustomerByFirstName(string firstName);
        Task<IEnumerable<Customer>> GetCustomerByLastName(string lastName);
    }
}
