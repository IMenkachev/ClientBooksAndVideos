using CustomerCommands.Domain.Products;

namespace CustomerCommands.Application.Contracts.Persistence
{
    public interface IPhysicalProductRepository : IAsyncRepository<PhysicalProduct>
    {
    }
}
