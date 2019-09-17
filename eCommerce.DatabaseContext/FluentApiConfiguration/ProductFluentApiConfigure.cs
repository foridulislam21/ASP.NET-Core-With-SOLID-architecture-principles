using System;
using System.Collections.Generic;
using System.Text;
using eCommerceApp.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace eCommerce.DatabaseContext.FluentApiConfiguration
{
    internal class ProductFluentApiConfigure : IEntityTypeConfiguration<Product>
    {
        public void Configure(EntityTypeBuilder<Product> builder)
        {
            builder.Property(p => p.Name).IsRequired();
            builder.Property(p => p.Price).IsRequired();
            builder.Property(p => p.CategoryId).IsRequired();
        }
    }
}