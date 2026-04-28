using System;
using System.Collections.Generic;
using System.Text;

namespace Task3
{
    public class CarProcessor
    {
        public List<Car> FilterByYear(List<Car> cars, int minYear)
        {
            var filteredCars = new List<Car>();

            foreach (var car in cars)
            {
                if (car.Year >= minYear)
                {
                    filteredCars.Add(car);
                }
            }

            return filteredCars;
        }
    }
}
