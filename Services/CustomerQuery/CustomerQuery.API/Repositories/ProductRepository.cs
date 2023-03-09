using CustomerQuery.API.Contracts;
using CustomerQuery.API.Persistence;
using MongoDB.Driver;
using CustomerQuery.API.Entities;

namespace CustomerQuery.API.Repositories
{
    public class ProductRepository : IProductRepository
    {
        private readonly IBooksAndVideosContext _context;

        public ProductRepository(IBooksAndVideosContext context)
        {
            _context = context ?? throw new ArgumentNullException(nameof(context));
        }

        public async Task<IEnumerable<Product>> GetAllAsync()
        {
            return await _context
                .Products
                .Find(p => true)
                .ToListAsync();
        }

        public async Task<Product> GetByIdAsync(Guid id)
        {
            return await _context
                .Products
                .Find(p => p.Id == id)
                .FirstOrDefaultAsync();
        }
    }
}
