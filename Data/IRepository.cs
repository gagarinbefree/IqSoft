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
        void CreateItem(T item);
    }
}
