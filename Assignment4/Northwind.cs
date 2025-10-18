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

    public DbSet<OrderDetails> orderDetails { get; set;} 

    // public DbSet<OrderDetails> GetOrderDetails()
    // {
    //     return orderDetails;
    // }

    // public void SetOrderDetails(DbSet<OrderDetails> value)
    // {
    //     orderDetails = value;
    // }

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
        modelBuilder.Entity<Order>().Property(o => o.Required).HasColumnName("requireddate");
        modelBuilder.Entity<Order>().Property(o => o.ShippedDate).HasColumnName("shippeddate");
        modelBuilder.Entity<Order>().Property(o => o.Freight).HasColumnName("freight");
        modelBuilder.Entity<Order>().Property(o => o.ShipName).HasColumnName("shipname");
        modelBuilder.Entity<Order>().Property(o => o.ShipCity).HasColumnName("shipcity");

        // OrderDetails Table
        modelBuilder.Entity<OrderDetails>().ToTable("orderdetails");
        // modelBuilder.Entity<OrderDetails>().Property(od => od.Id).HasColumnName("orderdetailid");
        // modelBuilder.Entity<OrderDetails>().Property(od => od.Id).HasColumnName("orderdetailid");

        modelBuilder.Entity<OrderDetails>().Property(od => od.UnitPrice).HasColumnName("unitprice");
        modelBuilder.Entity<OrderDetails>().Property(od => od.Quantity).HasColumnName("quantity");
        modelBuilder.Entity<OrderDetails>().Property(od => od.Discount).HasColumnName("discount");
        modelBuilder.Entity<OrderDetails>().Property(c => c.OrderId).HasColumnName("orderid");
        modelBuilder.Entity<OrderDetails>().Property(c => c.ProductId).HasColumnName("productid");
        modelBuilder.Entity<OrderDetails>().HasKey(x => new { x.OrderId, x.ProductId });



        // Product Table
        modelBuilder.Entity<Product>().ToTable("products");
        modelBuilder.Entity<Product>().Property(p => p.Id).HasColumnName("productid");
        modelBuilder.Entity<Product>().Property(p => p.Name).HasColumnName("productname");
        modelBuilder.Entity<Product>().Property(p => p.UnitPrice).HasColumnName("unitprice");
        modelBuilder.Entity<Product>().Property(p => p.QuantityPerUnit).HasColumnName("quantityperunit");
        modelBuilder.Entity<Product>().Property(p => p.UnitsInStock).HasColumnName("unitsinstock");
        modelBuilder.Entity<Product>().Property(c => c.CategoryId).HasColumnName("categoryid");


        //mapping here
        // modelBuilder.Entity<Product>()
        // .HasOne(p => p.Category)
        // .WithMany(c => c.Products)
        // .HasForeignKey("categoryid");

        // Category Table
        modelBuilder.Entity<Category>().ToTable("categories");
        modelBuilder.Entity<Category>().Property(c => c.Id).HasColumnName("categoryid");
        modelBuilder.Entity<Category>().Property(c => c.Name).HasColumnName("categoryname");
        modelBuilder.Entity<Category>().Property(c => c.Description).HasColumnName("description");
    }

    private object Product()
    {
        throw new NotImplementedException();
    }
}


