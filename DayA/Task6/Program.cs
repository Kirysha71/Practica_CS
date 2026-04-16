using static System.Console;

namespace Task6
{
    internal class Program
    {
        static void Main(string[] args)
        {
            double x = 1;

            double part1 = Math.Log(2 * x);

            double numerator = Math.Pow(Math.Sin(x), 2) + 1;
            double denominator = 2 * Math.Sqrt(Math.Pow(Math.E, 2) + 1) - Math.Cos(x - Math.PI);

            double y = part1 + (numerator / denominator);

            WriteLine($"При x = {x}");
            WriteLine($"y = {y}"); 
        }
    }
}
