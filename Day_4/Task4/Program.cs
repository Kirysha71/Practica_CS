using System.Threading.Channels;
using static System.Console;

namespace Task4
{
    internal class Program
    {
        static void Main(string[] args)
        {
            List<string> strings = new List<string> { "ауди", "порше", "мазератти", "бмв", "мерседес" };

            WriteLine("До сортировки:");
            foreach (var x in strings)
                WriteLine(x);

            List<string> sorted = strings.SortByLength();

            WriteLine("После сортировки по длине:");
            foreach (var x in sorted)
                WriteLine(x);
        }
    }
}
