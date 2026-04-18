using System.Text;

namespace Task9
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.ForegroundColor = ConsoleColor.Magenta;
            Console.Write("Введите текст: ");
            StringBuilder sb = new StringBuilder(Console.ReadLine());

            Console.WriteLine("До:   " + sb);

            for (int left = 0, right = sb.Length - 1; left < right; left++, right--)
            {
                char temp = sb[left];
                sb[left] = sb[right];
                sb[right] = temp;
            }

            Console.WriteLine("После: " + sb);
        }
    }
}
