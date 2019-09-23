using System;
using System.Collections.Generic;
using System.Text;

namespace eCommerceApp.Models
{
    public class Product
    {
        public long Id { get; set; }
        public string Name { get; set; }
        public double Price { get; set; }
        public DateTime ExpireDate { get; set; }
        public string Description { get; set; }
        public int CategoryId { get; set; }
        public byte[] Image { get; set; }
        public Category Category { get; set; }
        public Stock Stock { get; set; }
    }
}