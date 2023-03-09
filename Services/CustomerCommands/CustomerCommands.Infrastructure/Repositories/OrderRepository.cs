using CustomerCommands.Application.Contracts.Persistence;
using CustomerCommands.Domain.Orders;
using CustomerCommands.Infrastructure.Persistence;

namespace CustomerCommands.Infrastructure.Repositories
{
    public class OrderRepository : RepositoryBase<Order>, IOrderRepository
    {
        public OrderRepository(BooksAndVideosContext dbContext) : base(dbContext)
        {
        }
    }
}
