using static System.Console;

namespace Task2
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Write("Введите трехзначное число: ");
            int number = int.Parse(Console.ReadLine());

            int d1 = number / 100;
            int d2 = (number % 10) / 10;
            int d3 = number % 10;

            bool isIncreasing = (d1 < d2) && (d2 < d3);
            bool isDecreasing = (d1 > d2) && (d2 > d3);

            bool result = isIncreasing || isDecreasing;
            WriteLine($"Истинность высказывания: {result}");
        }
    }
}
