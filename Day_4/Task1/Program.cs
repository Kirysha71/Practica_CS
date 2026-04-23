namespace Task1
{
    internal class Program
    {
        static void Main(string[] args)
        {
            double radius = 5;

            Console.WriteLine($"Площадь круга с радиусом {radius}: {MathCircle.CalculateCircleArea(radius):F2}");
        }
    }
}
