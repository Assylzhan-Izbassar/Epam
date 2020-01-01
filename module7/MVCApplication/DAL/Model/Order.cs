using System;
using System.Collections.Generic;
using System.Text;

namespace DAL.Model
{
    public class Order
    {
        public int OrderID { get; set; }
        public int ProductID { get; set; }
        public int CustomerID { get; set; }
        public string CustomerName { get; set; }
        public DateTime ShipedDate { get; set; }
        public string ToState { get; set; }
        public string ToCity { get; set; }
        public string ToStreet { get; set; }
        public string ToZip { get; set; }

        public virtual ICollection<ProductOrder> Products { get; set; }
        public virtual Customer Customer { get; set; }
    }
}
