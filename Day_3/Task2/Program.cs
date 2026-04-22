namespace Task2
{
    internal class Program
    {
        static void Main(string[] args)
        {   
            List<Person> people = new List<Person>
            {
                new Person { Name = "Иван", City = "Брест" },
                new Person { Name = "Петр", City = "Брест" },
                new Person { Name = "Анна", City = "Гродно" },
                new Person { Name = "Мария", City = "Брест" },
                new Person { Name = "Олег", City = "Гродно" }
            };

            string[] cities;
            int[] counts;

            PeopleCounter.CountPeopleInCity(people, out cities, out counts);

            Console.WriteLine("Количество людей по городам:");
            for (int i = 0; i < cities.Length; i++)
            {
                Console.WriteLine($"{cities[i]}: {counts[i]} чел.");
            }
        }
    }
}
