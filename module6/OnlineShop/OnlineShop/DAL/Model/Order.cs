using System;
using System.Collections.Generic;
using System.Text;

namespace OnlineShop.DAL.Model
{
    public class Order
    {
        public int OrderID { get; set; }
        public Customer Customer { get; set; }
        public int ProductID { get; set; }
        public Product Product { get; set; }
        public int CustomerID { get; set; }
        public string CustomerName { get; set; }
        DateTime ShipDate { get; set; }
        public string ToState { get; set; }
        public string ToCity { get; set; }
        public string ToStreet { get; set; }
        public string ToZip { get; set; }

    }
}
