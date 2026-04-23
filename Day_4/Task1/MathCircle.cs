using System;
using System.Collections.Generic;
using System.Text;

namespace Task1
{
    public class MathCircle
    {
        public static double CalculateCircleArea(double radius)
        {
            if(radius < 0)
            {
                throw new ArgumentException("Радиус не может быть отрицательным");
            }

            return Math.PI * radius * radius;
        }
    }
}
