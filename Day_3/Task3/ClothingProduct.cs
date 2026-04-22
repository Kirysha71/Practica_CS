using System;
using System.Collections.Generic;
using System.Text;

namespace Task3
{
    public sealed class ClothingProduct : Product
    {
        public ClothingProduct(string name, decimal price, int stockQuantity)
            : base(name, "Одежда", price, stockQuantity)
        {
        }
    }
}
