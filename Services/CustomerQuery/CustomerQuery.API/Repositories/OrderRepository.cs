using CustomerQuery.API.Contracts;
using CustomerQuery.API.Persistence;
using CustomerQuery.API.Entities;
using MongoDB.Driver;

namespace CustomerQuery.API.Repositories
{
    public class OrderRepository : IOrderRepository
    {
        private readonly IBooksAndVideosContext _context;

        public OrderRepository(IBooksAndVideosContext context)
        {
            _context = context ?? throw new ArgumentNullException(nameof(context));
        }

        public async Task<IEnumerable<Order>> GetAllAsync()
        {
            return await _context
                .Orders
                .Find(o => true)
                .ToListAsync();
        }

        public async Task<Order> GetByIdAsync(Guid id)
        {
            return await _context
                .Orders
                .Find(o => o.Id == id)
                .FirstOrDefaultAsync();
        }
    }
}
