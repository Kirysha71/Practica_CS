using System;
using System.Collections.Generic;
using System.Text;

namespace Task3
{
    public sealed class ElectronicsProduct : Product
    {
        public ElectronicsProduct(string name, decimal price, int stockQuantity)
            : base(name, "Электроника", price, stockQuantity)
        {
        }
    }
}
