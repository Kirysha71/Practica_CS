using static System.Console;

namespace Task4
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Write("Введите x: ");
            double x = double.Parse(ReadLine());

            double y;

            if (x > 6.7)
            {
                y = 4 - Math.Exp(4 * x);
            }
            else
            {
                y = Math.Log(3.5 + x);
            }

            WriteLine($"y = {y:F4}");
            ReadKey();
        }
    }
}
