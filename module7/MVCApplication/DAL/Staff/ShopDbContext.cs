﻿using DAL.Model;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace DAL
{
    public class ShopDbContext : DbContext
    {
        public ShopDbContext()
        {
        }
        public ShopDbContext(DbContextOptions<ShopDbContext> options) : base(options)
        {
        }
        public DbSet<Customer> Customers { get; set; }
        public DbSet<Seller> Sellers { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<ProductOrder> ProductOrders { get; set; }
        public DbSet<Card> Cards { get; set; }
        public DbSet<Comment> Comments { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            string connectionString = @"Server=.\SQLEXPRESS;Database=OnlineShopMVC;Trusted_Connection=True;";
            optionsBuilder.UseSqlServer(connectionString, b => b.MigrationsAssembly("MVCApplication"));
            optionsBuilder.UseLazyLoadingProxies();
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Customer>().HasMany(x => x.Orders).WithOne(x => x.Customer);
            modelBuilder.Entity<Product>().HasMany(x => x.Orders).WithOne(x => x.Product);
            modelBuilder.Entity<Order>().HasMany(x => x.Products).WithOne(x => x.Order);
        }
    }
}