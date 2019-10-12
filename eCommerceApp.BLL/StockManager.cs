using System;
using System.Collections.Generic;
using System.Text;
using eCommerceApp.Abstractions.BLL;
using eCommerceApp.Abstractions.Repositories;
using eCommerceApp.Abstractions.Repositories.Base;
using eCommerceApp.BLL.Base;
using eCommerceApp.Models;

namespace eCommerceApp.BLL
{
    public class StockManager: Manager<Stock>, IStockManager
    {
        private readonly IStockRepository _stockRepository;

        public StockManager(IStockRepository stockRepository) : base(stockRepository)
        {
            _stockRepository = stockRepository;
        }
    }
}
