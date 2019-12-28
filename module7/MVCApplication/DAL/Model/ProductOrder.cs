using System;
using System.Collections.Generic;
using System.Text;

namespace DAL.Model
{
    public class ProductOrder
    {
        public int ProductOrderID { get; set; }
        public int ProductID { get; set; }
        public int? OrderID { get; set; }

        public virtual Product Product { get; set; }
        public virtual Order Order { get; set; }
    }
}
