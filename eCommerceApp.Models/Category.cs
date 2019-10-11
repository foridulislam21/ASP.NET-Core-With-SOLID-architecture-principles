using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace eCommerceApp.Models
{
    public class Category
    {
        public Category()
        {
            Products = new List<Product>();
        }

        public long Id { get; set; }
        public string Name { get; set; }
        public long? ParentId { get; set; }
        public Category Parent { get; set; }

        [InverseProperty("Parent")]
        public List<Category> ChildList { get; set; }

        public ICollection<Product> Products { get; set; }
    }
}