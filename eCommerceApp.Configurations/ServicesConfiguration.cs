using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Text;
using eCommerce.DatabaseContext;
using eCommerceApp.Abstractions.BLL;
using eCommerceApp.Abstractions.Repositories;
using eCommerceApp.BLL;
using eCommerceApp.Repositories;
using Microsoft.EntityFrameworkCore;

namespace eCommerceApp.Configurations
{
    public class ServicesConfiguration
    {
        public static void ConfigureServices(IServiceCollection services)
        {
            //Category
            services.AddTransient<ICategoryManager, CategoryManager>();
            services.AddTransient<ICategoryRepository, CategoryRepository>();
            //product
            services.AddTransient<IProductManager, ProductManager>();
            services.AddTransient<IProductRepository, ProductRepository>();
            //stock
            services.AddTransient<IStockManager, StockManager>();
            services.AddTransient<IStockRepository, StockRepository>();
            //DbContext
            services.AddTransient<DbContext, DatabaseDbContext>();
            services.AddTransient<DatabaseDbContext>();
        }
    }
}