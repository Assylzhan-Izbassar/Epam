using System;
using System.Collections.Generic;
using System.Text;
using DAL.Models;
using Microsoft.EntityFrameworkCore;

namespace DAL.Staff
{
    public class AwardDbContext : DbContext
    {
        public AwardDbContext()
        {
        }

        public AwardDbContext(DbContextOptions<AwardDbContext> options) : base(options)
        {
        }

        public DbSet<User> Users { get; set; }
        public DbSet<Award> Awards { get; set; }
        public DbSet<Role> Roles { get; set; }
        public DbSet<UserAward> UserAwards { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            string connectionString = @"Server = .\SQLEXPRESS; Database = TestDB; Trusted_Connection = True;";
            optionsBuilder.UseSqlServer(connectionString);
            optionsBuilder.UseLazyLoadingProxies();
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            string adminEmail = "mrjack@gmail.com";
            string adminPassword = "1e2r3t";

            Role adminRole = new Role { RoleId = 1, Name = "admin" };
            Role userRole = new Role { RoleId = 2, Name = "user" };
            User admin = new User {
                UserID = 1,
                Name = "Jack",
                Birthdate = DateTime.Now,
                Email = adminEmail, 
                Password = adminPassword,
                RoleId = adminRole.RoleId 
            };

            modelBuilder.Entity<Role>().HasData(new Role[] { adminRole, userRole });
            modelBuilder.Entity<User>().HasData(new User[] { admin });

            modelBuilder.Entity<Award>().HasMany(x => x.Users).WithOne(x => x.Awards);
            modelBuilder.Entity<User>().HasMany(x => x.UserAwards).WithOne(x => x.Users);
            modelBuilder.Entity<User>().HasOne(x => x.Role).WithMany(x => x.Users);

            base.OnModelCreating(modelBuilder);
        }
    }
}
