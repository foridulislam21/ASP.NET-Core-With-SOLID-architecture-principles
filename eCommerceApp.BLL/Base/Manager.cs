using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using eCommerceApp.Abstractions.BLL.Base;
using eCommerceApp.Abstractions.Repositories.Base;

namespace eCommerceApp.BLL.Base
{
    public abstract class Manager<T> : IManager<T> where T : class
    {
        private readonly IRepository<T> _repository;

        public Manager(IRepository<T> repository)
        {
            _repository = repository;
        }

        public virtual async Task<bool> Add(T entity)
        {
            return await _repository.Add(entity);
        }

        public virtual async Task<bool> Remove(T entity)
        {
            return await _repository.Remove(entity);
        }

        public virtual async Task<bool> Update(T entity)
        {
            return await _repository.Update(entity);
        }

        public virtual async Task<ICollection<T>> GetAll()
        {
            return await _repository.GetAll();
        }

        public virtual async Task<T> GetById(long id)
        {
            return await _repository.GetById(id);
        }
    }
}