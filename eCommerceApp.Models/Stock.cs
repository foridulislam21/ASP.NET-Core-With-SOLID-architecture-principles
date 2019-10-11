using System;
using System.Collections.Generic;
using System.Reflection.Metadata;
using System.Text;

namespace eCommerceApp.Models
{
    public class Stock
    {
        public long Id { get; set; }
        public long TotalStock { get; set; }
        public long ProductId { get; set; }
        public Product Product { get; set; }
    }
}