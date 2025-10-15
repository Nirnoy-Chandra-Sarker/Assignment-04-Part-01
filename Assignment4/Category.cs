using System;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using Assignment4;
using System.Collections.Generic;

namespace Assignment4
{
    public class Category
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }

        public ICollection<Product> Products { get; set; }
    }
}


