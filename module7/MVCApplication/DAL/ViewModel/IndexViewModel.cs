using DAL.Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace DAL.ViewModel
{
    public class IndexViewModel
    {
        public IEnumerable<CustomerModel> Customers { get; set; }
        public IEnumerable<ProductModel> Products { get; set; }
        public IEnumerable<ProductOrder> ProductOrders { get; set; }
        public Order Order { get; set; }
        public Product Product { get; set; }
        public ProductOrder ProductOrder { get; set; }
    }
}
