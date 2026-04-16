using static System.Console;

namespace Task3
{
    internal class Program
    {
        static void Main(string[] args)
        {
            WriteLine("Сравнение двух формул");

            WriteLine("Введите угол a (в градусах)");
            double a = double.Parse(Console.ReadLine());

            double alpha = a * Math.PI / 180;

            double numerator = Math.Sin(2 * alpha) + Math.Sin(5 * alpha) - Math.Sin(3 * alpha);
            double denominator = Math.Cos(alpha) + 1 - 2 * Math.Pow(Math.Sin(2 * alpha), 2);
            double z1 = numerator / denominator;

            double z2 = 2 * Math.Sin(alpha);

            WriteLine(z1);
            WriteLine(z2);
        }
    }
}
