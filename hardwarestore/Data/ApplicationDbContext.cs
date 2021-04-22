using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace hardwarestore.Data
{
    public class ApplicationDbContext : IdentityDbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        } 
        public DbSet<Employee> Employees { get; set; }
        public DbSet<ProductDetails> ProdDetails { get; set; }
        public DbSet<ProductHistory> ProdHistories { get; set; }
        public DbSet<Supplier> Suppliers { get; set; }
        public DbSet<Customer> Customers { get; set; }
         public DbSet<SalesItem> SalesItems { get; set; }


    }
}
