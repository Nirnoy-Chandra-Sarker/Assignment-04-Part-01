using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using Assignment4;

namespace Assignment4
{


    public class Order
    {
        public int Id { get; set; }
        public DateTime Date { get; set; }
        public DateTime RequiredDate { get; set; }
        public DateTime? ShippedDate { get; set; }
        public decimal Freight { get; set; }
        public string ShipName { get; set; }
        public string ShipCity { get; set; }

        public ICollection<OrderDetail> OrderDetails { get; set; }
    }
}
