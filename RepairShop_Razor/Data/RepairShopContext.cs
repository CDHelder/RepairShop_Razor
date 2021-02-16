using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using RepairShop_Razor.Models;

namespace RepairShop_Razor.Data
{
    public class RepairShopContext : DbContext
    {
        public RepairShopContext (DbContextOptions<RepairShopContext> options)
            : base(options)
        {
        }

        public DbSet<Customer> Customers { get; set; }
        public DbSet<Employee> Employees { get; set; }
        public DbSet<RepairOrder> RepairOrders { get; set; }
        public DbSet<Part> Parts { get; set; }
        public DbSet<RepairOrderDetail> RepairOrderDetails { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Customer>().ToTable("Customer");
            modelBuilder.Entity<Employee>().ToTable("Employee");
            modelBuilder.Entity<RepairOrder>().ToTable("RepairOrder");
            modelBuilder.Entity<Part>().ToTable("Part");
            modelBuilder.Entity<RepairOrderDetail>().ToTable("RepairOrderDetail");
            modelBuilder.Entity<RepairOrder>().HasMany(x => x.RepairOrderDetails);
            //modelBuilder.Entity<RepairOrderDetail>().HasOne(p => p.RepairOrder).WithMany(b => b.RepairOrderDetail);
        }
    }
}
