using System;
using System.Collections.Generic;
using System.Text;

namespace eCommerceApp.Models.ApiViewModels
{
    public class ProductDto
    {
        public long Id { get; set; }

        public string Name { get; set; }
        public double Price { get; set; }
        public DateTime? ExpireDate { get; set; }

        public bool IsActive { get; set; }

        public int CategoryId { get; set; }
        public string CategoryName { get; set; }
    }
}