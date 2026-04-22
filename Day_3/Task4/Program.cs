namespace Task4
{
    internal class Program
    {
        static void Main(string[] args)
        {
            RentalCar[] cars = new RentalCar[]
            {
                new RentalCar("Toyota", "Camry", 2022, 3500, true),
                new RentalCar("Audi", "RS7", 2024, 10000, true),
                new RentalCar("BMW", "X5", 2023, 7000, false),
                new RentalCar("Audi", "80", 1988, 2008, true),
                new RentalCar("Mercedes", "E-Class", 2023, 6500, true)
            };

            RentalService service = new RentalService(cars);

            service.DisplayAllCars();

            Console.WriteLine("Доступны");
            RentalCar[] availableCars = service.GetAvailableCars();
            foreach (var car in availableCars)
            {
                Console.WriteLine(car);
            }
            Console.WriteLine();

            Console.WriteLine("Автомобили марки Audi");
            RentalCar[] audiCars = service.GetCarsByBrand("Audi");
            foreach (var car in audiCars)
            {
                Console.WriteLine(car);
            }
            Console.WriteLine();
            Console.WriteLine("Тестирование аренды");
            availableCars[0].Rent();
            service.DisplayAllCars();

            availableCars[0].Return();
            service.DisplayAllCars();
        }
    }
}
