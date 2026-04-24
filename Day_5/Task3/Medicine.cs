using System;
using System.Collections.Generic;
using System.Text;

namespace Task3
{
    public abstract class Medicine
    {
        public string Name { get; }
        public string Manufacturer {  get; }
        protected Medicine(string  name, string manufacturer)
        {
            Name = name;
            Manufacturer = manufacturer;
        }
    }
}
