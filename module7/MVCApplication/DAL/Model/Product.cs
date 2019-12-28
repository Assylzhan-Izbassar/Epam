using System;
using System.Collections.Generic;
using System.Text;

namespace DAL.Model
{
    public class Product
    {
        public int ProductID { get; set; }
        public string ProductName { get; set; }
        public string Quantity { get; set; }
        public double Price { get; set; }
        public DateTime DateOfProduction { get; set; }
        public int UnitsInStock { get; set; }
        public int UnitsOnOrder { get; set; }

        public virtual ICollection<ProductOrder> Orders { get; set; }
    }
}
