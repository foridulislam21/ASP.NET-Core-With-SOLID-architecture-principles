using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using eCommerce.DatabaseContext;
using eCommerceApp.Models;

namespace eCommerceApp.Repositories
{
    public class CategoryRepository
    {
        private readonly DatabaseDbContext _db;

        public CategoryRepository(DatabaseDbContext db)
        {
            _db = db;
        }

        public ICollection<Category> GetAll()
        {
            return _db.Categories.ToList();
        }
    }
}