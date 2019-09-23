using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using eCommerceApp.Abstractions.Repositories.Base;
using Microsoft.EntityFrameworkCore;

namespace eCommerceApp.Repositories.Base
{
    public abstract class EfRepository<T> : IRepository<T> where T : class
    {
        private readonly DbContext _db;

        protected EfRepository(DbContext db)
        {
            _db = db;
        }

        public virtual async Task<bool> Add(T entity)
        {
            _db.Set<T>().Add(entity);
            return await _db.SaveChangesAsync() > 0;
        }

        public virtual async Task<bool> Remove(T entity)
        {
            _db.Set<T>().Remove(entity);
            return await _db.SaveChangesAsync() > 0;
        }

        public virtual async Task<bool> Update(T entity)
        {
            _db.Entry(entity).State = EntityState.Modified;
            return await _db.SaveChangesAsync() > 0;
        }

        public virtual async Task<T> GetById(long id)
        {
            return await _db.Set<T>().FindAsync(id);
        }

        public virtual async Task<ICollection<T>> GetAll()
        {
            return await _db.Set<T>().ToListAsync();
        }
    }
}