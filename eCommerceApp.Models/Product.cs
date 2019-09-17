using System;
using System.Collections.Generic;
using System.Text;

namespace eCommerceApp.Models
{
    public class Product
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public DateTime ExpireTime { get; set; }
        public double Price { get; set; }
        public int CategoryId { get; set; }
        public Category Category { get; set; }
        public Stock Stock { get; set; }
    }
}