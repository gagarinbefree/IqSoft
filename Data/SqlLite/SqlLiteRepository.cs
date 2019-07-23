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

        public void Create(T item)
        {
            if (item == null)
                throw new Exception("Нет объекта для сохранения");

            _db.Set<T>().Add(item);
        }

        public async Task<T> GetAsync(Expression<Func<T, bool>> where, params Expression<Func<T, Object>>[] includes)
        {
            IQueryable<T> q = _db.Set<T>();
            if (where != null)
                q = q.Where(where);

            return await includes.Aggregate(q, (c, p) => c.Include(p)).FirstOrDefaultAsync();
        }

        public async Task<List<T>> GetAllAsync(Expression<Func<T, bool>> where, params Expression<Func<T, Object>>[] includes)
        {
            IQueryable<T> q = _db.Set<T>();
            if (where != null)
                q = q.Where(where);

            return await includes.Aggregate(q, (c, p) => c.Include(p)).ToListAsync();
        }

        public void Delete(T item)
        {
            _db.Set<T>().Remove(item);           
        }

        public void Update(T item)
        {
            _db.Set<T>().Attach(item);
            _db.Entry(item).State = EntityState.Modified;
        }
    }
}
