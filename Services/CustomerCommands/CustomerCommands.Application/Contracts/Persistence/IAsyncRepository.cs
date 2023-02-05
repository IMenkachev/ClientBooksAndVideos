using CustomerCommands.Domain.Common;

namespace CustomerCommands.Application.Contracts.Persistence
{
    public interface IAsyncRepository<T> where T : EntityBase
    {
        Task<T> GetByIdAsync(int id);
        Task<T> AddAsync(T entity);
        Task<T> SaveAsync(T entity);  
        Task<T> DeleteAsync(T entity);  
    }
}
