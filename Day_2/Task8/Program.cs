using static System.Console;

namespace Task8
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Write("Введите текст: ");
            string text = ReadLine();

            string[] words = text.Split(' ');

            WriteLine("Слова, которые встречаются только 1 раз:");

            ConsoleColor[] colors = { ConsoleColor.Green, ConsoleColor.Cyan, ConsoleColor.Yellow, ConsoleColor.Magenta, ConsoleColor.Red };
            int colorIndex = 0;

            for (int i = 0; i < words.Length; i++)
            {
                if (words[i] == "") continue;

                int count = 0;
                for (int j = 0; j < words.Length; j++)
                {
                    if (words[i] == words[j])
                    {
                        count++;
                    }
                }

                if (count == 1)
                {
                    ForegroundColor = colors[colorIndex];
                    Write(words[i] + " ");
                    ResetColor();

                    colorIndex++;
                    if (colorIndex >= colors.Length) colorIndex = 0;
                }
            }
            WriteLine();
        }
    }
}
