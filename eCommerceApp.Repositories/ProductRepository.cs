using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using eCommerce.DatabaseContext;
using eCommerceApp.Models;

namespace eCommerceApp.Repositories
{
    public class ProductRepository
    {
        private DatabaseDbContext _db;

        public ProductRepository(DatabaseDbContext databaseDbContext)
        {
            _db = databaseDbContext;
        }

        public ICollection<Product> GetAll()
        {
            return _db.Products.ToList();
        }

        public bool Add(Product product)
        {
            _db.Products.Add(product);
            return _db.SaveChanges() > 0;
        }
    }
}