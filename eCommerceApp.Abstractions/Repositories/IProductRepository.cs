using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using eCommerceApp.Abstractions.Repositories.Base;
using eCommerceApp.Models;

namespace eCommerceApp.Abstractions.Repositories
{
    public interface IProductRepository : IRepository<Product>
    {
    }
}