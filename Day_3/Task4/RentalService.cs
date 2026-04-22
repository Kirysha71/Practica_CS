using System;
using System.Collections.Generic;
using System.Text;

namespace Task4
{
    public class RentalService
    {
        private RentalCar[] cars;

        public RentalService(RentalCar[] cars)
        {
            this.cars = cars;
        }

        public RentalCar[] GetAvailableCars()
        {
            return cars.Where(c => c.IsAvailable).ToArray();
        }

        public RentalCar[] GetCarsByBrand(string brand)
        {
            return cars.Where(c => c.Brand.Equals(brand, StringComparison.OrdinalIgnoreCase)).ToArray();
        }

        public void DisplayAllCars()
        {
            Console.WriteLine("Все автомобили");
            foreach (var car in cars)
            {
                Console.WriteLine(car);
            }
            Console.WriteLine();
        }
    }
}
