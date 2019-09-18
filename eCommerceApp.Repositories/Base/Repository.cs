using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using Microsoft.EntityFrameworkCore;

namespace eCommerceApp.Repositories.Base
{
    public abstract class EfRepository<T> where T : class
    {
        private readonly DbContext _db;

        protected EfRepository(DbContext db)
        {
            _db = db;
        }

        public bool Add(T entity)
        {
            _db.Set<T>().Add(entity);
            return _db.SaveChanges() > 0;
        }

        public bool Remove(T entity)
        {
            _db.Set<T>().Remove(entity);
            return _db.SaveChanges() > 0;
        }

        public bool Update(T entity)
        {
            _db.Entry(entity).State = EntityState.Modified;
            return _db.SaveChanges() > 0;
        }

        public T GetById(int id)
        {
            return _db.Set<T>().Find(id);
        }

        public ICollection<T> GetAll()
        {
            return _db.Set<T>().ToList();
        }
    }
}