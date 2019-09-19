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
    public class ProductRepository : EfRepository<Product>, IProductRepository
    {
        private DatabaseDbContext _db;

        public ProductRepository(DatabaseDbContext db) : base(db)
        {
            _db = db;
        }
    }
}