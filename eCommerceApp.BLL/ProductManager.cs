using System;
using System.Collections.Generic;
using System.Text;
using eCommerceApp.Models;
using eCommerceApp.Repositories;

namespace eCommerceApp.BLL
{
    public class ProductManager
    {
        private readonly ProductRepository _productRepository;

        public ProductManager(ProductRepository productRepository)
        {
            _productRepository = productRepository;
        }

        public ICollection<Product> GetAll()
        {
            return _productRepository.GetAll();
        }

        public bool Add(Product product)
        {
            return _productRepository.Add(product);
        }
    }
}