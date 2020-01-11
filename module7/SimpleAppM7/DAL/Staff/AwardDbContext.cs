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

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            string connectionString = @"Server = .\SQLEXPRESS; Database = AwardDB; Trusted_Connection = True;";
            optionsBuilder.UseSqlServer(connectionString);
        }
    }
}
