using System;
using System.Collections.Generic;
using System.Text;

namespace Task3
{
    public class OnlineStore
    {
        private Product[] products;

        public OnlineStore(Product[] products)
        {
            this.products = products;
        }

        public Product[] GetOutOfStockProducts()
        {
            return products.Where(p => p.StockQuantity == 0).ToArray();
        }

        public Product GetMostExpensiveProduct()
        {
            if (products.Length == 0)
                return null;

            return products.OrderByDescending(p => p.Price).First();
        }
    }
}
