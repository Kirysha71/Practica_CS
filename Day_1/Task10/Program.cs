namespace Task10
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Трёхзначные автоморфные числа:");

            for (int n = 100; n <= 999; n++)
            {
                int square = n * n;
                int lastDigits = square % 1000;

                if (lastDigits == n)
                {
                    Console.WriteLine($"{n}^2 = {square} (последние цифры: {lastDigits})");
                }
            }
        }
    }
}
