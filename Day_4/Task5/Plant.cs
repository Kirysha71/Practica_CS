using System;
using System.Collections.Generic;
using System.Text;

namespace Task5
{
    public abstract class Plant
    {
        public string Name { get; set; }
        public abstract void Grow();
        public virtual void DisplayInfo()
        {
            Console.WriteLine($"Растение: {Name}");
        }
    }
}
