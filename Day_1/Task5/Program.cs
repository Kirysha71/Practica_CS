using static System.Console;

namespace Task5
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Write("Введите сторону a: ");
            double a = double.Parse(ReadLine());

            Write("Введите сторону b: ");
            double b = double.Parse(ReadLine());

            Write("Введите сторону c: ");
            double c = double.Parse(ReadLine());

            bool isEquilateral = (a == b) && (b == c);

            if (isEquilateral)
            {
                WriteLine("Равносторонний");
            }
            else
            {
                WriteLine("Не равносторонний");
            }
        }
    }
}
