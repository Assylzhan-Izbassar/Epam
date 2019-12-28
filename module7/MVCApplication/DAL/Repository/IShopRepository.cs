using DAL.Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace DAL
{
    public interface IShopRepository : IDisposable
    {
        IEnumerable<Product> GetProducts();
        Product GetProductByID(int productID);
        bool InsertProduct(Product product);
        bool UpdateProduct(Product product);
        bool DeleteProduct(int productID);
        void Save();
        IEnumerable<Order> GetOrders();
        Order GetOrderByID(int orderID);
        bool InsertOrder(Order order);
        bool DeleteOrder(int orderID);
        IEnumerable<Customer> GetCustomers();
        Customer GetCustomerByID(int customerID);
        bool InsertCustomer(Customer customer);
        bool UpdateCustomer(Customer customer);
        bool DeleteCustomer(int customerID);
    }
}
