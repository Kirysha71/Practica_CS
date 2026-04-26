using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;

namespace Task1
{
    public class ShoppingCart
    {
        private readonly Hashtable _items;

        public ShoppingCart()
        {
            _items = new Hashtable(); 
        }

        public void Add(Product product)
        {
            _items.Add(product.Id, product);
        }

        public void Remove(int id)
        {
            _items.Remove(id);
        }
        public Product Get(int id)
        {
            return (Product)_items[id];
        }

        public int Count => _items.Count;
    }
}
