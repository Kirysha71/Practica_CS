using System;
using System.Collections.Generic;
using System.Globalization;
using System.Text;

namespace Task3
{
    public abstract class Product
    {
        public string Name { get; set; }
        public string Category { get; set; }
        public decimal Price { get; set; }
        public int StockQuantity { get; set; }

        protected Product(string name, string category, decimal price, int stockQuantity)
        {
            Name = name;
            Category = category;
            Price = price;
            StockQuantity = stockQuantity;
        }
    }
}
