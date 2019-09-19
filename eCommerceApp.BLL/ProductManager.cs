using System;
using System.Collections.Generic;
using System.Text;
using eCommerceApp.Abstractions.BLL;
using eCommerceApp.Abstractions.BLL.Base;
using eCommerceApp.Abstractions.Repositories;
using eCommerceApp.BLL.Base;
using eCommerceApp.Models;

namespace eCommerceApp.BLL
{
    public class ProductManager : Manager<Product>, IProductManager
    {
        private readonly IProductRepository _productRepository;

        public ProductManager(IProductRepository productRepository) : base(productRepository)
        {
            _productRepository = productRepository;
        }
    }
}