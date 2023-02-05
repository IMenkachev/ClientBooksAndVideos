using CustomerQuery.API.Data;
using CustomerQuery.API.Entities;
using MongoDB.Driver;

namespace CustomerQuery.API.Repositories
{
    public class CustomerRepository : ICustomerRepository
    {
        private readonly ICustomerContext _context;

        public CustomerRepository(ICustomerContext context)
        {
            _context = context ?? throw new ArgumentNullException(nameof(context));
        }

        public async Task<Customer> GetCustomer(int customerId)
        {
            return await _context
                .Customers
                .Find(c => c.Id == customerId)
                .FirstOrDefaultAsync();
        }

        public async Task<IEnumerable<Customer>> GetCustomerByFirstName(string firstName)
        {
            return await _context
                .Customers
                .Find(c => c.FirstName == firstName)
                .ToListAsync();
        }

        public async Task<IEnumerable<Customer>> GetCustomerByLastName(string lastName)
        {
            return await _context
                .Customers
                .Find(c => c.LastName == lastName)
                .ToListAsync();
        }

        public async Task<IEnumerable<Customer>> GetCustomers()
        {
            return await _context
                .Customers
                .Find(c => true)
                .ToListAsync();
        }
    }
}
