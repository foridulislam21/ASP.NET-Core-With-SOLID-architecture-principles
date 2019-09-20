using System;
using System.Collections.Generic;
using System.Text;

namespace eCommerceApp.Models
{
    public class Customer
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Address { get; set; }
        public string Email { get; set; }
        public long MobileNo { get; set; }
    }
}