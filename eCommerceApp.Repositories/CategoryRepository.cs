using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using eCommerce.DatabaseContext;
using eCommerceApp.Abstractions.Repositories;
using eCommerceApp.Models;
using eCommerceApp.Repositories.Base;
using Microsoft.EntityFrameworkCore;

namespace eCommerceApp.Repositories
{
    public class CategoryRepository : EfRepository<Category>, ICategoryRepository
    {
        private readonly DatabaseDbContext _db;

        public CategoryRepository(DbContext db) : base(db)
        {
            _db = db as DatabaseDbContext;
        }
    }
}