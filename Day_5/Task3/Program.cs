namespace Task3
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Medicine[] medicines = new Medicine[]
            {
                new Antibiotic("Амоксиклав", "Лек", 500),
                new CoughSyrup("Амбробене", "Ратиофарм", 100),
                new Antibiotic("Сумамед", "Плива", 250),
                new CoughSyrup("Лазолван", "Берингер", 200),
                new CoughSyrup("Проспан", "Энгельхард", 150)
            };

            Console.WriteLine("Все сиропы:");
            var syrups = medicines.OfType<CoughSyrup>();
            foreach (var syrup in syrups)
            {
                Console.WriteLine($"- {syrup.Name} ({syrup.Manufacturer})");
            }
        }
    }
}
