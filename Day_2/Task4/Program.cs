using static System.Console;

namespace Task4
{
    internal class Program
    {
        static void Main(string[] args)
        {
            ForegroundColor = ConsoleColor.Green;
            int[,] salary = new int[20, 12];
            Random random = new Random();

            for(int i = 0; i < 20; i++)
            {
                for(int j = 0; j < 12; j++)
                {
                    salary[i, j] = random.Next(700, 9000);
                    Write($"{salary[i, j],20}");
                }
                WriteLine();
            }

            int sumFebruary = 0;

            for(int i = 0;i < 20; i++)
            {
                sumFebruary += salary[i, 1];
            }

            int sumOctober = 0;

            for(int i = 0; i < 20; i++)
            {
                sumOctober += salary[i, 9];
            }

            WriteLine("Общая зарплата в феврале: " + sumFebruary);
            WriteLine("Общая зарплата в октябре: " + sumOctober);
        }
    }
}
