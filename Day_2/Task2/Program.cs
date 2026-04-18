namespace Task2
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.ForegroundColor = ConsoleColor.Magenta;
            double[] mas = { 5.2, 3.1, 8.0, 2.5, 7.3, 1.0, 9.5, 4.2, 6.1, 3.3,
                       2.1, 5.5, 4.0, 8.2, 3.1, 6.0, 2.5, 7.0, 1.5, 5.0 };

            Console.WriteLine("Исходный массив: ");
            for (int i = 0; i < mas.Length; i++)
            {
                Console.Write($"{mas[i]}  ");
            }

            for (int i = 0; i < 10; i++)
            {
                if (mas[i] < mas[i + 10])
                {
                    double el = mas[i];
                    mas[i] = mas[i + 10];
                    mas[i + 10] = el;
                }
            }

            Console.WriteLine("\nПреобразованный массив:");

            for(int i = 0; i < mas.Length; i++)
            {
                Console.Write($"{mas[i]}  ");
            }
        }
    }
}
