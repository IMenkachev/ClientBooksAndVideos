using CustomerCommands.Domain.Common;

namespace CustomerCommands.Application.Contracts.Persistence
{
    public interface IAsyncRepository<T> where T : EntityBase
    {
        Task<T> GetByIdAsync(Guid id);
        Task<T> AddAsync(T entity);
        Task<T> UpdateAsync(T entity);
        Task<T> SaveAsync(T entity);  
        Task<T> DeleteAsync(T entity);
    }
}
