using Data.Dto;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Data.SqlLite
{
    public class SqlLiteRepository<T> : IRepository<T> where T : Entity
    {
        private SqlLiteDbContext _db;

        public SqlLiteRepository(SqlLiteDbContext db)
        {
            _db = db;
        }
       
        public async Task<T> GetAsync(Expression<Func<T, bool>> where)
        {
            IQueryable<T> q = _db.Set<T>().Where(where);

            return await q.FirstOrDefaultAsync();
        }

        public void CreateItem(T item)
        {
            if (item == null)
                throw new Exception("Нет объекта для сохранения");

            _db.Set<T>().Add(item);
        }        
    }
}
