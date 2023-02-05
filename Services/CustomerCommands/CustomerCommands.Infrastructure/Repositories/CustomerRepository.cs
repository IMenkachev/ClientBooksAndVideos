using CustomerCommands.Application.Contracts.Persistence;
using CustomerCommands.Domain.Entities;
using CustomerCommands.Infrastructure.Persistence;
using Microsoft.EntityFrameworkCore;

namespace CustomerCommands.Infrastructure.Repositories
{
    public class CustomerRepository : RepositoryBase<Customer>, ICustomerRepository
    {
        private readonly CustomerContext _dbContext;
        public CustomerRepository(CustomerContext dbContext) : base(dbContext)
        {
            _dbContext= dbContext ?? throw new ArgumentNullException(nameof(dbContext));
        }

        public async Task<IEnumerable<Customer>> GetCustomers()
        {
            return await _dbContext
                .Customers
                .ToListAsync();
        }
    }
}
