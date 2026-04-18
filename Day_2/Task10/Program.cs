using System.Text.RegularExpressions;

namespace Task10
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.ForegroundColor = ConsoleColor.Magenta;
            Console.Write("Введите строку: ");
            string text = Console.ReadLine();

            string result = Regex.Replace(text, @"\d", "");

            Console.WriteLine("Результат: " + result);
        }
    }
}
