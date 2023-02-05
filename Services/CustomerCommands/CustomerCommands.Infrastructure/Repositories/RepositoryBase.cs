﻿using CustomerCommands.Application.Contracts.Persistence;
using CustomerCommands.Domain.Common;
using CustomerCommands.Infrastructure.Persistence;

namespace CustomerCommands.Infrastructure.Repositories
{
    public class RepositoryBase<T> : IAsyncRepository<T> where T : EntityBase
    {
        protected readonly CustomerContext _dbContext;

        public RepositoryBase(CustomerContext dbContext)
        {
            _dbContext = dbContext ?? throw new ArgumentNullException(nameof(dbContext));
        }

        public async Task<T> AddAsync(T entity)
        {
            _dbContext.Add(entity);
            await _dbContext.SaveChangesAsync();    
            return entity;
        }

        public async Task<T> DeleteAsync(T entity)
        {
            _dbContext.Remove(entity);
            await _dbContext.SaveChangesAsync();    
            return entity;  
        }

        public async Task<T> GetByIdAsync(int id)
        {
            return await _dbContext.Set<T>().FindAsync(id);
        }

        public async Task<T> SaveAsync(T entity)
        {  
            await _dbContext.SaveChangesAsync();    
            return entity;
        }
    }
}
