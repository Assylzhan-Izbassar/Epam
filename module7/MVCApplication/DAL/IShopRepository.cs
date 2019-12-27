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
        void Save();
    }
}
