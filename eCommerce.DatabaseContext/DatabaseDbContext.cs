using System;
using System.Collections.Generic;
using System.Text;
using eCommerce.DatabaseContext.FluentApiConfiguration;
using eCommerceApp.Models;
using Microsoft.EntityFrameworkCore;

namespace eCommerce.DatabaseContext
{
    public class DatabaseDbContext : DbContext
    {
        public DbSet<Product> Products { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Stock> Stocks { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Server=(local);Database=eCommerceApp;Integrated Security=true");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new ProductFluentApiConfigure());
            modelBuilder.ApplyConfiguration(new CategoryFluentApiConfigure());
        }
    }
}