using CustomerCommands.Application.Contracts.Persistence;
using CustomerCommands.Domain.Products;
using CustomerCommands.Infrastructure.Persistence;
using Microsoft.EntityFrameworkCore;

namespace CustomerCommands.Infrastructure.Repositories
{
    public class ProductRepository : RepositoryBase<Product>, IProductRepository
    {
        public ProductRepository(BooksAndVideosContext dbContext) : base(dbContext)
        {
        }

        public async Task<ICollection<Product>> GetAll() => await _dbContext
            .Products
            .ToListAsync();

        public async Task<ICollection<Product>> GetByIdAsync(ICollection<Guid> productIds)
        {
            if (productIds?.Any() == true)
            {
                return await _dbContext.Products!
                    .AsQueryable<Product>()
                    .Where(p => productIds.Contains(p.Id))
                    .ToListAsync();
            }

            return new List<Product>();
        }
    }
}
