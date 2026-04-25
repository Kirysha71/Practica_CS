using System;
using System.Collections.Generic;
using System.Text;

namespace Task3
{
    public class DisplayPanel
    {
        public DisplayPanel(WeatherStation station)
        {
            station.WeatherChanged += OnWeatherChanged;
        }

        private void OnWeatherChanged(object sender, string condition)
        {
            Console.WriteLine($"Обновление данных - {condition}");
        }
    }
}
