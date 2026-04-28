using static System.Console;

namespace Task3
{
    internal class Program
    {
        static void Main(string[] args)
        {
            File.WriteAllLines("cars.txt", new[]
            {
                "Geely,2024",
                "Zeekr,2026",
                "Xiaomi,2025",
                "Audi,2009",
                "Жигули,1999"
            });

            var reader = new CarFileReader();
            var cars = reader.ReadCars();

            WriteLine("Все автомобили:");
            foreach (var car in cars)
            {
                WriteLine($"{car.Brand} - {car.Year}");
            }

            var processor = new CarProcessor();
            var newCars = processor.FilterByYear(cars, 2010);

            WriteLine("Автомобили с 2010 года:");
            foreach (var car in newCars)
            {
                WriteLine($"{car.Brand} - {car.Year}");
            }
        }
    }
}
