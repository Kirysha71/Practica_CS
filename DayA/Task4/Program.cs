using System.Transactions;
using static System.Console;

namespace Task4
{
    internal class Program
    {
        static void Main(string[] args)
        {
            WriteLine("Введите вещественные числа:");
            Write("a = ");
            double a = double.Parse(ReadLine());

            Write("b = ");
            double b = double.Parse(ReadLine());

            Write("c = ");
            double c = double.Parse(ReadLine());
            
            Write("d = ");
            double d = double.Parse(ReadLine());

            double result = (a / b) + (c / d);

            WriteLine($"{a:F2}/{b:F2} + {c:F2}/{d:F2} = {result:F2}");
        }
    }
}
