namespace Task3
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.Write("N -- ");
            int N = int.Parse(Console.ReadLine());

            double sum = 0;

            int sign = 1;

            for(int i = 0; i <= N; i++)
            {
                double number = 1 + i * 0.1;
                sum = sum + sign * number;
                sign = -sign;
            }

            Console.WriteLine(sum);
        }
    }
}
