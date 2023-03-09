using CustomerCommands.Application.Contracts.Persistence;
using CustomerCommands.Domain.Products;
using CustomerCommands.Infrastructure.Persistence;

namespace CustomerCommands.Infrastructure.Repositories
{
    public class PhysicalProductRepository : RepositoryBase<PhysicalProduct>, IPhysicalProductRepository
    {
        public PhysicalProductRepository(BooksAndVideosContext dbContext) : base(dbContext)
        {
        }
    }
}
