using System;
using System.Collections.Generic;
using System.Reflection.Metadata;
using System.Text;

namespace eCommerceApp.Models
{
    public class Stock
    {
        public Stock()
        {
            Products = new List<Product>();
        }

        public int Id { get; set; }
        public double TotalStock { get; set; }
        public ICollection<Product> Products { get; set; }
    }
}