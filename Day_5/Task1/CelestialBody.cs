using System;
using System.Collections.Generic;
using System.Text;

namespace Task1
{
    abstract class CelestialBody
    {
        public string Name { get; protected set; }
        public CelestialBody(string name)
        {
            Name = name;
        }

        public abstract string GetType();
        public abstract string GetInfo();
    }
}
