using CustomerQuery.API.Contracts;
using CustomerQuery.API.Persistence;
using CustomerQuery.API.Entities;
using MongoDB.Driver;

namespace CustomerQuery.API.Repositories
{
    public class CustomerRepository : ICustomerRepository
    {
        private readonly IBooksAndVideosContext _context;

        public CustomerRepository(IBooksAndVideosContext context)
        {
            _context = context ?? throw new ArgumentNullException(nameof(context));
        }

        public async Task<IEnumerable<Customer>> GetAllAsync()
        {
            return await _context
                .Customers
                .Find(c => true)
                .ToListAsync();
        }

        public async Task<Customer> GetByIdAsync(Guid id)
        {
            return await _context
                .Customers
                .Find(c => c.Id == id)
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
    }
}
