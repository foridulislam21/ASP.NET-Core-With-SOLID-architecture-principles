using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using eCommerce.DatabaseContext;
using eCommerceApp.Abstractions.Repositories;
using eCommerceApp.Models;
using eCommerceApp.Models.ApiViewModels;
using eCommerceApp.Repositories.Base;
using Microsoft.EntityFrameworkCore;

namespace eCommerceApp.Repositories
{
    public class ProductRepository : EfRepository<Product>, IProductRepository
    {
        private readonly DatabaseDbContext _db;

        public ProductRepository(DbContext db) : base(db)
        {
            _db = db as DatabaseDbContext;
        }

        public override async Task<ICollection<Product>> GetAll()
        {
            return await _db.Products
                .Include(c => c.Category)
                .ToListAsync();
        }

        public ICollection<Product> GetByCriteria(ProductSearchCriteriaVm productSearchCriteria)
        {
            var products = _db.Products.AsQueryable();
            if (productSearchCriteria != null)
            {
                if (!string.IsNullOrEmpty(productSearchCriteria.Name))
                {
                    products = products.Where(p => p.Name.ToLower().Contains(productSearchCriteria.Name.ToLower()));
                }

                if (productSearchCriteria.FromPrice > 0)
                {
                    products = products.Where(p => p.Price >= productSearchCriteria.FromPrice);
                }

                if (productSearchCriteria.ToPrice > 0)
                {
                    products = products.Where(p => p.Price <= productSearchCriteria.ToPrice);
                }

                if (!string.IsNullOrEmpty(productSearchCriteria.CategoryName))
                {
                    products = products.Where(p => p.Name.ToLower().Contains(productSearchCriteria.Name.ToLower()));
                }
            }

            return products.ToList();
        }
    }
}