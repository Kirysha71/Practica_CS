using System;
using System.Collections.Generic;
using System.Text;

namespace Task5
{
    public class Tree : Plant
    {
        public int Height { get; set; }
        public override void Grow()
        {
            Console.WriteLine("Tree is growing");
        }
        public override void DisplayInfo()
        {
            Console.WriteLine($"Дерево: {Name}, Высота: {Height} м");
        }
    }
}
