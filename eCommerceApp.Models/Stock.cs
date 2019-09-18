using System;
using System.Collections.Generic;
using System.Reflection.Metadata;
using System.Text;

namespace eCommerceApp.Models
{
    public class Stock
    {
        public int Id { get; set; }
        public int TotalStock { get; set; }
        public int ProductId { get; set; }
        public Product Product { get; set; }
    }
}