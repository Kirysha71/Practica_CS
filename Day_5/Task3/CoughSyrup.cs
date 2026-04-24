using System;
using System.Collections.Generic;
using System.Text;

namespace Task3
{
    public class CoughSyrup : Medicine, ILiquidMedicine
    {
        public double VolumeMl { get; }

        public CoughSyrup(string name, string manufacturer, double volumeMl)
            : base(name, manufacturer)
        {
            VolumeMl = volumeMl;
        }

        public void TakeLiquid()
        {
            Console.WriteLine($"Принять сироп: {Name} ({VolumeMl}мл)");
        }
    }
}
