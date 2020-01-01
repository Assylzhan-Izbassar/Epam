using DAL.Model;
using System;
using System.Collections.Generic;
using System.Linq;

namespace DAL
{
    public class ShopRepository : IShopRepository
    {
        private ShopDbContext _shopDbContext;
        private bool disposed = false;

        public ShopRepository(ShopDbContext shopDbContext)
        {
            _shopDbContext = shopDbContext;
        }

        protected virtual void Dispose(bool disposing)
        {
            if(!this.disposed && disposing)
            {
                _shopDbContext.Dispose();
            }
            this.disposed = true;
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        public Product GetProductByID(int productID)
        {
            return _shopDbContext.Products.Find(productID);
        }

        public IEnumerable<Product> GetProducts()
        {
            return _shopDbContext.Products;
        }

        public bool InsertProduct(Product product)
        {
            if(product != null)
            {
                _shopDbContext.Products.Add(product);
                var productOrder = new ProductOrder()
                {
                    Product = product
                };
                _shopDbContext.ProductOrders.Add(productOrder);
                return true;
            }
            return false;
        }

        public void Save()
        {
            _shopDbContext.SaveChanges();
        }

        public bool UpdateProduct(Product product)
        {
            if(product != null)
            {
                _shopDbContext.Entry(product).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
                return true;
            }
            return false;
        }

        public bool DeleteProduct(int productID)
        {
            Product product = _shopDbContext.Products.Find(productID);
            if(product != null)
            {
                _shopDbContext.Products.Remove(product);
                return true;
            }
            return false;
        }

        public IEnumerable<Order> GetOrders()
        {
            return _shopDbContext.Orders;
        }

        public Order GetOrderByID(int orderID)
        {
            return _shopDbContext.Orders.Find(orderID);
        }

        public bool InsertOrder(Order order)
        {
            if(order != null)
            {
                _shopDbContext.Orders.Add(order);
                return true;
            }
            return false;
        }

        public bool DeleteOrder(int orderID)
        {
            Order order = _shopDbContext.Orders.Find(orderID);
            if (order != null)
            {
                _shopDbContext.Orders.Remove(order);
                return true;
            }
            return false;
        }

        public IEnumerable<Customer> GetCustomers()
        {
            return _shopDbContext.Customers;
        }

        public Customer GetCustomerByID(int customerID)
        {
            var customer = _shopDbContext.Customers.Find(customerID);
            return customer;
        }

        public bool InsertCustomer(Customer customer)
        {
            if(customer != null)
            {
                _shopDbContext.Customers.Add(customer);
                return true;
            }
            return false;
        }

        public bool UpdateCustomer(Customer customer)
        {
            if (customer != null)
            {
                _shopDbContext.Entry(customer).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
                return true;
            }
            return false;
        }

        public bool DeleteCustomer(int customerID)
        {
            var customer = _shopDbContext.Customers.Find(customerID);
            if(customer != null)
            {
                _shopDbContext.Customers.Remove(customer);
                return true;
            }
            return false;
        }

        public IEnumerable<ProductOrder> GetProductOrder()
        {
            return _shopDbContext.ProductOrders;
        }

        public bool UpdateOrder(Order order)
        {
            if (order != null)
            {
                _shopDbContext.Entry(order).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
                return true;
            }
            return false;
        }
    }
}
