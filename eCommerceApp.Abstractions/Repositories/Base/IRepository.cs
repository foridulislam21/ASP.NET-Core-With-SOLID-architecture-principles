using System.Collections.Generic;
using System.Threading.Tasks;

namespace eCommerceApp.Abstractions.Repositories.Base
{
    public interface IRepository<T> where T : class
    {
        Task<bool> Add(T entity);

        Task<bool> Remove(T entity);

        Task<bool> Update(T entity);

        Task<ICollection<T>> GetAll();

        Task<T> GetById(long id);
    }
}