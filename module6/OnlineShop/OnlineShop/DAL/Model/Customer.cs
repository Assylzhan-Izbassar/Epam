using System;
using System.Collections.Generic;
using System.Text;

namespace OnlineShop.DAL.Model
{
    public class Customer
    {
        public int CustomerID { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public string Street { get; set; }
        public string City { get; set; }
        public string Zip { get; set; }
        public string PhoneNumber { get; set; }

        public ICollection<Order> Orders { get; set; }
    }
}
