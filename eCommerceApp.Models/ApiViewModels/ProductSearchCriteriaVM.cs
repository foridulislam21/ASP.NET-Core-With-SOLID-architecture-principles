using System;
using System.Collections.Generic;
using System.Text;

namespace eCommerceApp.Models.ApiViewModels
{
    public class ProductSearchCriteriaVm
    {
        public string Name { get; set; }
        public double FromPrice { get; set; }
        public double ToPrice { get; set; }
        public string CategoryName { get; set; }
    }
}