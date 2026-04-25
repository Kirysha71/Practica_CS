namespace Task3
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var station = new WeatherStation();
            var display = new DisplayPanel(station);
            var warning = new WarningSystem(station);

            station.SetWeather("Солнечно");
            station.SetWeather("шторм");
        }
    }
}
