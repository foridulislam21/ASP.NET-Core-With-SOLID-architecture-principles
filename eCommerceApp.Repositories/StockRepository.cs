using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using eCommerce.DatabaseContext;
using eCommerceApp.Models;
using eCommerceApp.Repositories.Base;

namespace eCommerceApp.Repositories
{
    public class StockRepository : EfRepository<Stock>
    {
        private readonly DatabaseDbContext _db;

        public StockRepository(DatabaseDbContext db) : base(db)
        {
            _db = db;
        }
    }
}