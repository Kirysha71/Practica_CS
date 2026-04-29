using Task2_1;

namespace Task2
{
    internal class Program
    {
        static void Main(string[] args)
        {
            List<int> numbers = new List<int> { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13 };

            var evenFilter = new DataFilter(new EvenNumberFilter());
            Console.WriteLine(string.Join(", ", evenFilter.Apply(numbers)));

            var primeFilter = new DataFilter(new PrimeNumberFilter());
            Console.WriteLine(string.Join(", ", primeFilter.Apply(numbers)));

            var rangeFilter = new DataFilter(new RangeFilter(3, 7));
            Console.WriteLine("От 3 до 7: " + string.Join(", ", rangeFilter.Apply(numbers)));
        }
    }
}
