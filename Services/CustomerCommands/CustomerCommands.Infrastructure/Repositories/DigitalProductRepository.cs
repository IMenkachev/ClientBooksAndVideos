using CustomerCommands.Application.Contracts.Persistence;
using CustomerCommands.Domain.Products;
using CustomerCommands.Infrastructure.Persistence;

namespace CustomerCommands.Infrastructure.Repositories
{
    public class DigitalProductRepository : RepositoryBase<DigitalProduct>, IDigitalProductRepository
    {
        public DigitalProductRepository(BooksAndVideosContext dbContext) : base(dbContext)
        {
        }
    }
}
