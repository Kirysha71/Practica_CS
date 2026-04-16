using System.Globalization;
using static System.Console;

namespace Task5
{
    internal class Program
    {
        static void Main(string[] args)
        {
            WriteLine("Введите четырехзначное число: ");
            int number = int.Parse(ReadLine());

            int firstDigit = number / 1000;
            int secondDigit = (number / 100) % 10;
            int thirdDigit = (number / 10) % 10;
            int fourthDigit = number % 10;

            int result = firstDigit * 1000 + thirdDigit*100 + secondDigit*10 + fourthDigit;
            WriteLine(result);
        }
    }
}