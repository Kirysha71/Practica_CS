namespace Task6
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.Write("Введите номер масти m : ");
            int m = int.Parse(Console.ReadLine());

            Console.Write("Введите номер карты k : ");
            int k = int.Parse(Console.ReadLine());

            string rank;
            switch (k)
            {
                case 6: rank = "шестерка"; break;
                case 7: rank = "семерка"; break;
                case 8: rank = "восьмерка"; break;
                case 9: rank = "девятка"; break;
                case 10: rank = "десятка"; break;
                case 11: rank = "валет"; break;
                case 12: rank = "дама"; break;
                case 13: rank = "король"; break;
                case 14: rank = "туз"; break;
                default: rank = "неизвестная"; break;
            }

            string suit;
            switch (m)
            {
                case 1: suit = "пик"; break;
                case 2: suit = "треф"; break;
                case 3: suit = "бубен"; break;
                case 4: suit = "червей"; break;
                default: suit = "неизвестной"; break;
            }

            Console.WriteLine($"{rank} {suit}");
        }
    }
}
