using CustomerCommands.Application.Contracts.Persistence;
using CustomerCommands.Domain.Customers;
using CustomerCommands.Infrastructure.Persistence;
using Microsoft.EntityFrameworkCore;

namespace CustomerCommands.Infrastructure.Repositories
{
    public class CustomerRepository : RepositoryBase<Customer>, ICustomerRepository
    {
        public CustomerRepository(BooksAndVideosContext dbContext) : base(dbContext)
        {
        }

        public async Task<IEnumerable<Customer>> GetAll() => await _dbContext
                .Customers
                .ToListAsync();
    }
}
