using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using eCommerceApp.Abstractions.BLL.Base;
using eCommerceApp.Models;
using eCommerceApp.Models.ApiViewModels;

namespace eCommerceApp.Abstractions.BLL
{
    public interface IProductManager : IManager<Product>
    {
        ICollection<Product> GetByCriteria(ProductSearchCriteriaVm productSearchCriteria);
    }
}