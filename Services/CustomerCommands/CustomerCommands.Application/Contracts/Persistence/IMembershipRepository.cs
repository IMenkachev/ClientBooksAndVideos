using CustomerCommands.Domain.Memberships;

namespace CustomerCommands.Application.Contracts.Persistence
{
    public interface IMembershipRepository : IAsyncRepository<Membership>
    {
        public Task<IEnumerable<Membership>> GetAll();
    }
}
