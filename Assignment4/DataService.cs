using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using Assignment4;

namespace Assignment4
{
    public class DataService
    {
        private readonly NorthwindContext _context;

        public DataService()
        {
            _context = new NorthwindContext();
        }

  

        public List<Category> GetCategories()
        {
            return _context.Categories.ToList();
        }

        public Category ? GetCategory(int id)
        {
            return _context.Categories.Find(id);
        }

        public Category CreateCategory(string name, string description)
        {
            var newCategory = new Category
            {
                Name = name,
                Description = description,
            };

            _context.Categories.Add(newCategory);
            _context.SaveChanges();
            return newCategory;
        }

        public bool DeleteCategory(int id)
        {
            var category = _context.Categories.Find(id);
            if (category != null)
            {
                _context.Categories.Remove(category);
                _context.SaveChanges();
                return true;
            }
            return false;
        }

        public bool UpdateCategory(int id, string newName, string newDescription)
        {
            var category = _context.Categories.Find(id);
            if (category != null)
            {
                category.Name = newName;
                category.Description = newDescription;
                _context.SaveChanges();
                return true;
            }
            return false;
        }



        public DTOProductExt GetProduct(int id)
        {
            var prod = _context.Products
                .Include(x => x.Category) 
                .Select(x => new DTOProductExt
                {
                    Id = x.Id,
                    Name = x.Name,
                    UnitPrice = x.UnitPrice,
                    QuantityPerUnit = x.QuantityPerUnit,
                    UnitsInStock = x.UnitsInStock,
                    CategoryName = x.Category.Name 
                }).FirstOrDefault(x => x.Id == id);

            return prod;
        }

        public ICollection<DTOProductCategory> GetProductByName(string s)
        {
            var searchedProducts = _context.Products
                .Include(x => x.Category)
                .Where(x => x.Name.ToLower().Contains(s.ToLower()))
                .Select(x => new DTOProductCategory
                {
                    ProductName = x.Name,
                    CategoryName = x.Category.Name 
                }).ToList();

            return searchedProducts;
        }

        public ICollection<DTOProductExt> GetProductByCategory(int categoryId)
        {
            var categoryProducts = _context.Products
                .Include(x => x.Category)
                .Where(x => x.CategoryId == categoryId)
                .Select(x => new DTOProductExt
                {
                    Id = x.Id,
                    Name = x.Name,
                    UnitPrice = x.UnitPrice,
                    QuantityPerUnit = x.QuantityPerUnit,
                    UnitsInStock = x.UnitsInStock,
                    CategoryName = x.Category.Name 
                }).ToList();

            return categoryProducts;
        }

  

        public Order GetOrder(int orderId)
        {
            var order = _context.Orders
                .Include(x => x.OrderDetails)
                    .ThenInclude(x => x.Product)
                        .ThenInclude(x => x.Category)
                .FirstOrDefault(x => x.Id == orderId);

            return order;
        }

        public ICollection<DTOOrderShipped> GetOrders(string shipName)
        {
            var orders = _context.Orders
                .Where(x => x.ShipName == shipName)
                .Select(x => new DTOOrderShipped
                {
                    OrderId = x.Id,
                    OrderDate = x.Date,
                    ShipName = x.ShipName,
                    ShipCity = x.ShipCity
                }).ToList();

            return orders;
        }

        public ICollection<DTOOrderShipped> GetOrders()
        {
            var orders = _context.Orders
                .Select(x => new DTOOrderShipped
                {
                    OrderId = x.Id,
                    OrderDate = x.Date,
                    ShipName = x.ShipName,
                    ShipCity = x.ShipCity
                }).ToList();

            return orders;
        }



        public ICollection<OrderDetail> GetOrderDetailsByOrderId(int orderId)
        {
            var orderDetails = _context.OrderDetails
                .Include(x => x.Product)
                .Where(x => x.OrderId == orderId)
                .ToList();

            return orderDetails;
        }

        public ICollection<OrderDetail> GetOrderDetailsByProductId(int productId)
        {
            var orderDetails = _context.OrderDetails
                .Include(x => x.Product)
                .Include(x => x.Order)
                .Where(x => x.ProductId == productId)
                .ToList();

            return orderDetails;
        }
    }
}
