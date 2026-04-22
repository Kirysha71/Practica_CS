using System;
using System.Collections.Generic;
using System.Text;

namespace Task4
{
    public partial class RentalCar
    {
        public void Rent()
        {
            if (IsAvailable)
            {
                IsAvailable = false;
                Console.WriteLine($"Автомобиль {Brand} {Model} взят в аренду.");
            }
            else
            {
                Console.WriteLine($"Автомобиль {Brand} {Model} уже арендован.");
            }
        }

        public void Return()
        {
            IsAvailable = true;
            Console.WriteLine($"Автомобиль {Brand} {Model} возвращен.");
        }
    }
}
