using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Data
{
    public interface IRepository<T>
    {
        Task<T> GetAsync(Expression<Func<T, bool>> where);
        Task<T> GetAsync(Expression<Func<T, bool>> where, params Expression<Func<T, Object>>[] includes);
        Task<List<T>> GetAllAsync(Expression<Func<T, bool>> where, params Expression<Func<T, Object>>[] includes);
        void Create(T item);
        void Delete(T item);
        void Update(T item);
    }
}
