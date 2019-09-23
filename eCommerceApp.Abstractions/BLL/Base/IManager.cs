using System.Collections.Generic;
using System.Threading.Tasks;

namespace eCommerceApp.Abstractions.BLL.Base
{
    public interface IManager<T> where T : class
    {
        Task<bool> Add(T entity);

        Task<bool> Remove(T entity);

        Task<bool> Update(T entity);

        Task<ICollection<T>> GetAll();

        Task<T> GetById(long id);
    }
}