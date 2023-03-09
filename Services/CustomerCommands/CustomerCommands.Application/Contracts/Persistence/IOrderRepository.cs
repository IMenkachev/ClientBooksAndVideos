using CustomerCommands.Domain.Orders;

namespace CustomerCommands.Application.Contracts.Persistence
{
    public interface IOrderRepository : IAsyncRepository<Order>
    {
    }
}
