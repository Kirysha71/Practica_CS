namespace Task7
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.ForegroundColor = ConsoleColor.Gray;
            Console.WriteLine("Введите текст: ");
            string text = Console.ReadLine();

            string[] words = text.Split(' ');

            for(int i = 0; i < words.Length; i++)
            {
                if (words[i].Length > 0)
                {
                    char first = char.ToUpper(words[i][0]);
                    string rest = words[i].Substring(1);
                    words[i] = first + rest;
                }
            }
            string result = string.Join(" ", words);
            Console.WriteLine("Результат: " + result);
        }
    }
}
