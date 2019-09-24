using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using eCommerce.DatabaseContext;
using eCommerceApp.Models;
using eCommerceApp.Repositories.Base;
using Microsoft.EntityFrameworkCore;

namespace eCommerceApp.Repositories
{
    public class StockRepository : EfRepository<Stock>
    {
        private readonly DatabaseDbContext _db;

        public StockRepository(DbContext db) : base(db)
        {
            _db = db as DatabaseDbContext;
        }
    }
}