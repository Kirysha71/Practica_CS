using static System.Console;

namespace Task7
{
    internal class Program
    {
        static int FindMax(int a, int b)
        {
            if (a > b)
                return a;
            else
                return b;
        }
        static double FindMax(double a, double b)
        {
            if (a > b)
                return a;
            else
                return b;
        }

        static void Main()
        {
            int resultInt = FindMax(3, 5);
            WriteLine($"Большее число  = {resultInt}"); 

            double resultDouble = FindMax(3.1, 2.9);
            WriteLine($"Большее число = {resultDouble}");
        }
    }
}
