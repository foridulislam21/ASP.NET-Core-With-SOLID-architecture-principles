using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using eCommerceApp.Abstractions.Repositories.Base;
using eCommerceApp.Models;
using eCommerceApp.Models.ApiViewModels;

namespace eCommerceApp.Abstractions.Repositories
{
    public interface IProductRepository : IRepository<Product>
    {
        ICollection<Product> GetByCriteria(ProductSearchCriteriaVm productSearchCriteria);
    }
}