using System;
using System.Collections.Generic;
using System.Text;

namespace Task3
{
    public class CarFileReader
    {
        public List<Car> ReadCars(string filePath = "cars.txt")
        {
            var cars = new List<Car>();

            foreach (var line in File.ReadAllLines(filePath))
            {
                var parts = line.Split(',');
                cars.Add(new Car
                {
                    Brand = parts[0],
                    Year = int.Parse(parts[1])
                });
            }

            return cars;
        }
    }
}
