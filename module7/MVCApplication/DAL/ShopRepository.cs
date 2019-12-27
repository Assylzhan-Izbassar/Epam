﻿using DAL.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

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
                return true;
            }
            return false;
        }

        public void Save()
        {
            _shopDbContext.SaveChanges();
        }
    }
}
