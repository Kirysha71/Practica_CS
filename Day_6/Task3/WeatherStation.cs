using System;
using System.Collections.Generic;
using System.Text;

namespace Task3
{
    public class WeatherStation
    {
        public event EventHandler<string> WeatherChanged;

        public void SetWeather(string condition)
        {
            Console.WriteLine($"Погода изменилась: {condition}");
            WeatherChanged?.Invoke(this, condition);
        }
    }
}
