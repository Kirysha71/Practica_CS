using static System.Console;

namespace Task8
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Write("Введите A: ");
            int A = int.Parse(ReadLine());

            Write("Введите B: ");
            int B = int.Parse(ReadLine());

            int product = 1;

            for (int i = A; i <= B; i++)
            {
                product = product * i;
            }

            WriteLine("Произведение: " + product);
        }
    }
}
