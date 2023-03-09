using CustomerCommands.Application.Contracts.Persistence;
using CustomerCommands.Domain.Memberships;
using CustomerCommands.Infrastructure.Persistence;
using Microsoft.EntityFrameworkCore;

namespace CustomerCommands.Infrastructure.Repositories
{
    public class MembershipRepository : RepositoryBase<Membership>, IMembershipRepository
    {
        public MembershipRepository(BooksAndVideosContext dbContext) : base(dbContext)
        {
        }

        public async Task<IEnumerable<Membership>> GetAll() => await _dbContext
                .Memberships
                .ToListAsync();
    }
}
