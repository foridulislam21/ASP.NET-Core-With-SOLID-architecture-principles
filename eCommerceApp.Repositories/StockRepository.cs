using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using eCommerce.DatabaseContext;
using eCommerceApp.Abstractions.Repositories;
using eCommerceApp.Models;
using eCommerceApp.Repositories.Base;
using Microsoft.EntityFrameworkCore;

namespace eCommerceApp.Repositories
{
    public class StockRepository : EfRepository<Stock>,IStockRepository
    {
        private readonly DatabaseDbContext _db;

        public StockRepository(DbContext db) : base(db)
        {
            _db = db as DatabaseDbContext;
        }

        public async override Task<ICollection<Stock>> GetAll()
        {
            return await _db.Stocks.Include(c => c.Product).ToListAsync();
        }
    }
}