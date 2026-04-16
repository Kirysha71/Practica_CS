using static System.Console;

namespace Task7
{
    internal class Program
    {
        static void Main(string[] args)
        {
            WriteLine("Расчет площади стены для поклейки обоев");

            Write("Введите ширину комнаты A: ");
            double A = double.Parse(ReadLine());

            Write("Введите высоту комнаты B: ");
            double B = double.Parse(ReadLine());

            WriteLine("Размеры окна:");
            Write("Ширина окна: ");
            double windowWidth = double.Parse(ReadLine());
            Write("Высота окна: ");
            double windowHeight = double.Parse(ReadLine());

            WriteLine("Размеры двери:");
            Write("Ширина двери: ");
            double doorWidth = double.Parse(ReadLine());
            Write("Высота двери: ");
            double doorHeight = double.Parse(ReadLine());

            double totalWallArea = (4 * A) * B;

            double windowArea = windowWidth * windowHeight;
            double doorArea = doorWidth * doorHeight;

            double wallpaperArea = totalWallArea - windowArea - doorArea;

            WriteLine($"Площадь стен для оклеивания обоями: {wallpaperArea:F2} м");
        }
    }
}
