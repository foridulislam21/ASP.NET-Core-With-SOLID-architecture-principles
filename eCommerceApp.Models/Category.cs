using System;
using System.Collections.Generic;
using System.Text;

namespace eCommerceApp.Models
{
    public class Category
    {
        public Category()
        {
            Products = new List<Product>();
        }

        public int Id { get; set; }
        public string Name { get; set; }
        public virtual ICollection<Product> Products { get; set; }
    }
}