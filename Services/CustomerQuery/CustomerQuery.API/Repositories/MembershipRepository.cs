using CustomerQuery.API.Contracts;
using CustomerQuery.API.Persistence;
using CustomerQuery.API.Entities;
using MongoDB.Driver;

namespace CustomerQuery.API.Repositories
{
    public class MembershipRepository : IMembershipRepository
    {
        private readonly IBooksAndVideosContext _context;

        public MembershipRepository(IBooksAndVideosContext context)
        {
            _context = context ?? throw new ArgumentNullException(nameof(context));
        }

        public async Task<IEnumerable<Membership>> GetAllAsync()
        {
            return await _context
                .Memberships
                .Find(m => true)
                .ToListAsync();
        }

        public async Task<Membership> GetByIdAsync(Guid id)
        {
            return await _context
                .Memberships
                .Find(m => m.Id == id)
                .FirstOrDefaultAsync();
        }
    }
}
