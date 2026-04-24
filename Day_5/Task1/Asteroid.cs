using System;
using System.Collections.Generic;
using System.Text;
using System.Xml.Linq;

namespace Task1
{
    class Asteroid : CelestialBody
    {
        public double Diametr { get; private set; }
        public Asteroid(string name, double diametr) : base(name)
        {
            Diametr = diametr;
        }

        public override string GetType()
        {
            return "Астероид";
        }
        public override string GetInfo()
        {
            return $"{GetType()}: {Name}, диаметр - {Diametr}";
        }
    }
}
