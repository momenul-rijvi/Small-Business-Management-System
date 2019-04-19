using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using BusinessManagementSystem.Models;

namespace BusinessManagementSystem.DatabaseContext
{
    public class BusinessManagementSystemDbContext : DbContext
    {
        public DbSet<Product> Products { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Supplier> Suppliers { get; set; }
        public DbSet<Customer> Customers { get; set; }
        public DbSet<Purchase> Purchases { get; set; }
        public DbSet<PurchaseDetails> PurchaseDetailses { get; set; }
    }
}