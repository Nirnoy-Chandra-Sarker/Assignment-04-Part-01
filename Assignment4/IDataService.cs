using System.Collections.Generic;

namespace Assignment4
{
    public interface IDataService
    {
        // Categories
        IList<Category> GetCategories();
        Category? GetCategory(int id);
        Category CreateCategory(string name, string description);
        bool UpdateCategory(int id, string newName, string newDescription);
        bool DeleteCategory(int id);

        // Products
        DTOProductExt GetProduct(int id);
        ICollection<DTOProductCategory> GetProductByName(string search); 
        ICollection<DTOProductExt> GetProductByCategory(int categoryId);

        // Orders
        Order GetOrder(int orderId);
        ICollection<DTOOrderShipped> GetOrders();
        ICollection<DTOOrderShipped> GetOrdersByShipName(string shipName);

        // Order Details
        ICollection<OrderDetails> GetOrderDetailsByOrderId(int orderId);
        ICollection<OrderDetails> GetOrderDetailsByProductId(int productId);
    }
}
