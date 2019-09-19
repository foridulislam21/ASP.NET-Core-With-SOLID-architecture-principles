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
            services.AddTransient<ICategoryManager, CategoryManager>();
            services.AddTransient<ICategoryRepository, CategoryRepository>();
            services.AddTransient<IProductManager, ProductManager>();
            services.AddTransient<IProductRepository, ProductRepository>();
            services.AddTransient<DbContext, DatabaseDbContext>();
            services.AddTransient<DatabaseDbContext>();
        }
    }
}