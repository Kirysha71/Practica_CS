using System;
using System.Collections.Generic;
using System.Text;

namespace Task1
{
    class Star : CelestialBody
    {
        public double Temperature { get; private set;  }
        public Star(string name, double temperature) : base(name)
        {
            Temperature = temperature; 
        }

        public override string GetType()
        {
            return "Звезда";
        }
        public override string GetInfo()
        {
            return $"{GetType()}: {Name}, температура {Temperature}";
        }
    }
}
