using CustomerCommands.Application.Contracts.Persistence;
using CustomerCommands.Domain.ShippingSlips;
using CustomerCommands.Infrastructure.Persistence;

namespace CustomerCommands.Infrastructure.Repositories
{
    public class ShippingSlipRepository : RepositoryBase<ShippingSlip>, IShippingSlipRepository
    {
        public ShippingSlipRepository(BooksAndVideosContext dbContext) : base(dbContext)
        {
        }
    }
}
