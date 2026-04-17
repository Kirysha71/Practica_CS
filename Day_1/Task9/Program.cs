namespace Task9
{
    internal class Program
    {
        static void Main(string[] args)
        {
            double A = 0.1;
            double B = 2.1;
            int M = 20;

            double H = (B - A) / M;

            double x = A;

            Console.WriteLine("Табулирование функции");

            for (int i = 1; i <= M; i++)
            {
                double y = Math.Pow(x, 2) - Math.Exp(x);

                Console.WriteLine($"{x:F4}{y:F4}");

                x = x + H;
            }
        }
    }
}
