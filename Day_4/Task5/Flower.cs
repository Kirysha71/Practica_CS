using System;
using System.Collections.Generic;
using System.Text;
using System.Xml.Linq;

namespace Task5
{
    public class Flower : Plant
    {
        public string Color { get; set; }

        public override void Grow()
        {
            Console.WriteLine("Flower is growing");
        }

        public override void DisplayInfo()
        {
            Console.WriteLine($"Цветок: {Name}, Цвет: {Color}");
        }
    }
}
