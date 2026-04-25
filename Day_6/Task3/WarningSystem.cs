using System;
using System.Collections.Generic;
using System.Text;

namespace Task3
{
    public class WarningSystem
    {
        public WarningSystem(WeatherStation station)
        {
            station.WeatherChanged += OnWeatherChanged;
        }

        private void OnWeatherChanged(object sender, string condition)
        {
            if (condition.Contains("шторм") || condition.Contains("гроза"))
            {
                Console.WriteLine("ВНИМАНИЕ! Опасное погодное условие!");
            }
        }
    }
}
