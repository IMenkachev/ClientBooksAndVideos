using CustomerQuery.API.Contracts;
using CustomerQuery.API.Persistence;
using CustomerQuery.API.Entities;
using MongoDB.Driver;

namespace CustomerQuery.API.Repositories
{
    public class OrderItemRepository : IOrderItemRepository
    {
        private readonly IBooksAndVideosContext _context;

        public OrderItemRepository(IBooksAndVideosContext context)
        {
            _context = context ?? throw new ArgumentNullException(nameof(context));
        }

        public async Task<IEnumerable<OrderItem>> GetAllAsync()
        {
            return await _context
                 .OrderItems
                 .Find(i => true)
                 .ToListAsync();
        }

        public async Task<OrderItem> GetByIdAsync(Guid id)
        {
            return await _context
                .OrderItems
                .Find(i => i.Id == id)
                .FirstOrDefaultAsync();
        }
    }
}
