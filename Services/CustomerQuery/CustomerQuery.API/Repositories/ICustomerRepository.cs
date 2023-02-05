using CustomerQuery.API.Entities;

namespace CustomerQuery.API.Repositories
{
    public interface ICustomerRepository
    {
        Task<IEnumerable<Customer>> GetCustomers();
        Task<Customer> GetCustomer(int customerId);
        Task<IEnumerable<Customer>> GetCustomerByFirstName(string firstName);
        Task<IEnumerable<Customer>> GetCustomerByLastName(string lastName);
    }
}
