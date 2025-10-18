using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using Assignment4;
using System.Net.NetworkInformation;

namespace Assignment4
{


    public class OrderDetails
    {
        // public int Id { get; set; }
        public int UnitPrice { get; set; }
        public int Quantity { get; set; }
        public double Discount { get; set; }
        public int ProductId { get; set; }

        public int OrderId { get; set; }
        public Order Order { get; set; }

        public Product Product { get; set; }
    }
}