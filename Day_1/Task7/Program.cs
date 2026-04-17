using static System.Console;

namespace Task7
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Write("Введите A: ");
            int A = int.Parse(ReadLine());

            Write("Введите B: ");
            int B = int.Parse(ReadLine());

            Write("Введите цифру X: ");
            int X = int.Parse(ReadLine());

            Write("Введите цифру Y: ");
            int Y = int.Parse(ReadLine());

            WriteLine("\nРезультат:");
            bool found = false;

            for (int i = B; i >= A; i--)
            {
                if (i % 2 != 0) continue;

                int lastDigit = Math.Abs(i) % 10;

                if (lastDigit == X || lastDigit == Y)
                {
                    Write(i + " ");
                    found = true;
                }
            }

            if (!found)
                WriteLine("Подходящих чисел нет.");

            WriteLine();
        }
    }
}
