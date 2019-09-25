using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using eCommerceApp.Abstractions.BLL;
using eCommerceApp.Abstractions.BLL.Base;
using eCommerceApp.Abstractions.Repositories;
using eCommerceApp.BLL.Base;
using eCommerceApp.Models;
using eCommerceApp.Models.ApiViewModels;

namespace eCommerceApp.BLL
{
    public class ProductManager : Manager<Product>, IProductManager
    {
        private readonly IProductRepository _productRepository;

        public ProductManager(IProductRepository productRepository) : base(productRepository)
        {
            _productRepository = productRepository;
        }

        public ICollection<Product> GetByCriteria(ProductSearchCriteriaVm productSearchCriteria)
        {
            return _productRepository.GetByCriteria(productSearchCriteria);
        }

        public override Task<bool> Remove(Product entity)
        {
            entity.IsActive = false;
            return _productRepository.Update(entity);
        }
    }
}