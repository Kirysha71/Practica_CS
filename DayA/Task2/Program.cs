using static System.Console;

namespace Task2
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Write("Введите трехзначное число: ");
            int number = int.Parse(ReadLine());

            int firstDigit = number / 100;
            int secondDigit = (number / 10) % 10;

            int sum = firstDigit + secondDigit;
            WriteLine($"Cумма первой и третьей цифры вашего числа = {sum}");
        }
    }
}
