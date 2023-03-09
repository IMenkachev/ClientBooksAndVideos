using CustomerCommands.Domain.Products;

namespace CustomerCommands.Application.Contracts.Persistence
{
    public interface IProductRepository : IAsyncRepository<Product>
    {
        Task<ICollection<Product>> GetAll();
        Task<ICollection<Product>>GetByIdAsync(ICollection<Guid> productIds);
    }
}
