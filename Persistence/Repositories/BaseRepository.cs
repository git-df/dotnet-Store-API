using Application.Contracts.Persistence;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using Persistence.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Persistence.Repositories
{
    public class BaseRepository<T> : IBaseRepository<T> where T : class
    {
        protected readonly StoreDbContext _storeDbContext;

        public BaseRepository(
            StoreDbContext storeDbContext)
        {
            _storeDbContext = storeDbContext;
        }

        public async Task<T?> Add(T entity)
        {
            await _storeDbContext.Set<T>().AddAsync(entity);
            await _storeDbContext.SaveChangesAsync();

            return entity;
        }

        public async Task<List<T>> AddRange(List<T> entities)
        {
            await _storeDbContext.Set<T>().AddRangeAsync(entities);
            await _storeDbContext.SaveChangesAsync();

            return entities;
        }

        public async Task Delete(T entity)
        {
            _storeDbContext.Set<T>().Remove(entity);
            await _storeDbContext.SaveChangesAsync();
        }

        public async Task DeleteById(int id)
        {
            var entity = await GetById(id);

            if (entity != null)
            {
                _storeDbContext.Set<T>().Remove(entity);
                await _storeDbContext.SaveChangesAsync();
            }
        }

        public async Task DeleteById(Guid id)
        {
            var entity = await GetById(id);

            if (entity != null)
            {
                _storeDbContext.Set<T>().Remove(entity);
                await _storeDbContext.SaveChangesAsync();
            }
        }

        public async Task DeleteRange(List<T> entities)
        {
            _storeDbContext.Set<T>().RemoveRange(entities);
            await _storeDbContext.SaveChangesAsync();
        }

        public async Task<List<T>> GetAll()
        {
            return await _storeDbContext.Set<T>().AsNoTracking().ToListAsync();
        }

        public async Task<T?> GetById(int id)
        {
            return await _storeDbContext.Set<T>()
                .FindAsync(id);
        }

        public async Task<T?> GetById(Guid id)
        {
            return await _storeDbContext.Set<T>()
                .FindAsync(id);
        }

        public async Task<T?> Update(T entity)
        {
            _storeDbContext.Entry(entity).State = EntityState.Modified;
            await _storeDbContext.SaveChangesAsync();

            return entity;
        }
    }
}
