using System;
using System.Collections.Generic;
using System.Text;

namespace Task1
{
    class Planet : CelestialBody
    {
        public double Mass {  get; private set; }
        public Planet(string name, double mass) : base(name)
        {
            Mass = mass;
        }
        public override string GetType()
        {
            return "Планета";
        }
        public override string GetInfo()
        {
            return $"{GetType()}: {Name}, Масса - {Mass} планет земля";
        }
    }
}
