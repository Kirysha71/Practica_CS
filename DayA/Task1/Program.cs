using static System.Console;

namespace Task1
{
    internal class Program
    {
        static void Main(string[] args)
        {
            WriteLine("Система пересчета из верст в километры");
            Write("Введите расстояние в верстах: ");
            double versts = double.Parse(ReadLine());
            double km = versts * 1.0668;
            WriteLine($"{versts} верст - это {km} км");
            ReadKey();
        }
    }
}
