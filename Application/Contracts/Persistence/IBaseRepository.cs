using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Contracts.Persistence
{
    public interface IBaseRepository<T> where T : class
    {
        Task<T?> GetById(int id);
        Task<T?> GetById(Guid id);
        Task<List<T>> GetAll();
        Task<T?> Add(T entity);
        Task<List<T>> AddRange(List<T> entities);
        Task<T?> Update(T entity);
        Task Delete(T entity);
        Task DeleteRange(List<T> entities);
        Task DeleteById(int id);
        Task DeleteById(Guid id);
    }
}
