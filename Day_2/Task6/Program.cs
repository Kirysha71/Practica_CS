namespace Task6
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.ForegroundColor = ConsoleColor.Blue;
            Console.WriteLine("Введите строку: ");
            string text = Console.ReadLine();

            int pairCount = 0;

            for(int i = 0; i < text.Length - 1; i++)
            {
                if (text[i] == text[i + 1])
                {
                    pairCount++;
                }
            }

            Console.WriteLine($"Количество пар: {pairCount}");
        }
    }
}
