using static System.Console;

namespace Task3
{
    internal class Program
    {
        static void Main(string[] args)
        {
            ForegroundColor = ConsoleColor.Cyan;

            Write("Введите размерность матрицы: ");
            int N = int.Parse(ReadLine());

            Write("Введите начало диапазона а (отрицательное число): ");
            int a = int.Parse(ReadLine());

            Write("Введите конец диапазона b: ");
            int b = int.Parse(ReadLine());

            int[,] mas = new int[N, N];

            Random random = new Random();
            
            for(int i = 0; i < N; i++)
            {
                for(int j = 0;  j < N; j++)
                {
                    mas[i, j] = random.Next(a, b + 1);
                    Write($"{mas[i, j],4}");
                }
                WriteLine();
            }

            int sum = 0;

            for(int i = 0; i < N; i++)
            {
                for(int j =0; j < N; j++)
                {
                    if (mas[i, j] < 0)
                    {
                        sum = sum + mas[i, j] * mas[i, j] ;
                    }
                }
            }
            WriteLine("Сумма квадратов отрицательных чисел: " + sum);

            for(int i = 0;i < N; i++)
            {   
                int min = mas[i, 0];
                for (int j = 1;j < N; j++)
                {
                    if(mas[i, j] < min)
                    {
                        min = mas[i, j];
                    }
                }
                WriteLine($"Строка: {(i + 1)} " + min );
            }
        }
    }
}
