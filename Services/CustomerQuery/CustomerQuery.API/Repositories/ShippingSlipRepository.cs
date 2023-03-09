using CustomerQuery.API.Contracts;
using CustomerQuery.API.Persistence;
using CustomerQuery.API.Entities;
using MongoDB.Driver;

namespace CustomerQuery.API.Repositories
{
    public class ShippingSlipRepository : IShippingSlipRepository
    {
        private readonly IBooksAndVideosContext _context;

        public ShippingSlipRepository(IBooksAndVideosContext context)
        {
            _context = context ?? throw new ArgumentNullException(nameof(context));
        }

        public async Task<IEnumerable<ShippingSlip>> GetAllAsync()
        {
            return await _context
                .ShippingSlips
                .Find(ss => true)
                .ToListAsync();
        }

        public async Task<ShippingSlip> GetByIdAsync(Guid id)
        {
            return await _context
                .ShippingSlips
                .Find(ss => ss.Id == id)
                .FirstOrDefaultAsync();
        }
    }
}
