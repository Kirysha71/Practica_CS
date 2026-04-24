using System;
using System.Collections.Generic;
using System.Text;

namespace Task3
{
    public class Antibiotic : Medicine, IPill
    {
        public int DosageMg {  get; }

        public Antibiotic(string name, string manufacturer, int dosageMg)
            : base(name, manufacturer)
        {
            DosageMg = dosageMg;
        }

        public void TakePill()
        {
            Console.WriteLine($"Принять таблетку: {Name} ({DosageMg}мг)");
        }
    }
}
