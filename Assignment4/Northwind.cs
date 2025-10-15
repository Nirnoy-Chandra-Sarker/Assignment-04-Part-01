using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using Assignment4;

namespace Assignment4;
public class NorthwindContext : DbContext
{
    public DbSet<Category> Categories { get; set; }
    public DbSet<Product> Products { get; set; }
    public DbSet<Order> Orders { get; set; }
    public DbSet<OrderDetail> OrderDetails { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.LogTo(Console.WriteLine, Microsoft.Extensions.Logging.LogLevel.Information);
        optionsBuilder.EnableSensitiveDataLogging();
        optionsBuilder.UseNpgsql("Host=localhost;db=northwind;uid=postgres;pwd=Nirnoy730@#!");
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        // Order Table
        modelBuilder.Entity<Order>().ToTable("orders");
        modelBuilder.Entity<Order>().Property(o => o.Id).HasColumnName("orderid");
        modelBuilder.Entity<Order>().Property(o => o.Date).HasColumnName("orderdate");
        modelBuilder.Entity<Order>().Property(o => o.RequiredDate).HasColumnName("requireddate");
        modelBuilder.Entity<Order>().Property(o => o.ShippedDate).HasColumnName("shippeddate");
        modelBuilder.Entity<Order>().Property(o => o.Freight).HasColumnName("freight");
        modelBuilder.Entity<Order>().Property(o => o.ShipName).HasColumnName("shipname");
        modelBuilder.Entity<Order>().Property(o => o.ShipCity).HasColumnName("shipcity");

        // OrderDetails Table
        modelBuilder.Entity<OrderDetail>().ToTable("orderdetails");
        modelBuilder.Entity<OrderDetail>().Property(od => od.Id).HasColumnName("orderdetailid");
        modelBuilder.Entity<OrderDetail>().Property(od => od.UnitPrice).HasColumnName("unitprice");
        modelBuilder.Entity<OrderDetail>().Property(od => od.Quantity).HasColumnName("quantity");
        modelBuilder.Entity<OrderDetail>().Property(od => od.Discount).HasColumnName("discount");

        // Product Table
        modelBuilder.Entity<Product>().ToTable("products");
        modelBuilder.Entity<Product>().Property(p => p.Id).HasColumnName("productid");
        modelBuilder.Entity<Product>().Property(p => p.Name).HasColumnName("productname");
        modelBuilder.Entity<Product>().Property(p => p.UnitPrice).HasColumnName("unitprice");
        modelBuilder.Entity<Product>().Property(p => p.QuantityPerUnit).HasColumnName("quantityperunit");
        modelBuilder.Entity<Product>().Property(p => p.UnitsInStock).HasColumnName("unitsinstock");

        // Category Table
        modelBuilder.Entity<Category>().ToTable("categories");
        modelBuilder.Entity<Category>().Property(c => c.Id).HasColumnName("categoryid");
        modelBuilder.Entity<Category>().Property(c => c.Name).HasColumnName("categoryname");
        modelBuilder.Entity<Category>().Property(c => c.Description).HasColumnName("description");
    }
}


