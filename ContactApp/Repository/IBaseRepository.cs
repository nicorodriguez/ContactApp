using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace ContactApp.Repository
{
    public interface IBaseRepository<T>
    {
        Task SaveAsync();
        Task<IEnumerable<T>> GetAll();
        Task<T> GetById(int id);
        Task Create(T entity);
        Task Update(T entity);
        Task Delete(T entity);
        bool Exists(Expression<Func<T, bool>> predicate);
    }
}
