using static System.Console;

namespace Task6
{
    class Program
    {
        static bool IsLeapYear(int year)
        {
            return (year % 4 == 0 && year % 100 != 0) || (year % 400 == 0);
        }

        static int DaysInMonth(int month, int year)
        {
            int[] days = { 31, 28, 31, 30, 31, 30, 31, 31, 30, 31, 30, 31 };

            if (month == 2 && IsLeapYear(year))
                return 29;

            return days[month - 1];
        }

        static int SecondsInMonth(int M, int Y)
        {
            int days = DaysInMonth(M, Y);
            return days * 24 * 60 * 60;
        }

        static void Main()
        {
            Write("Введите год Y: ");
            int Y = int.Parse(ReadLine());

            Write("Введите месяц M1: ");
            int M1 = int.Parse(ReadLine());

            Write("Введите месяц M2: ");
            int M2 = int.Parse(ReadLine());

            Write("Введите месяц M3: ");
            int M3 = int.Parse(ReadLine());

            WriteLine($"Количество секунд в месяце {M1} года {Y}: {SecondsInMonth(M1, Y)}");
            WriteLine($"Количество секунд в месяце {M2} года {Y}: {SecondsInMonth(M2, Y)}");
            WriteLine($"Количество секунд в месяце {M3} года {Y}: {SecondsInMonth(M3, Y)}");
        }
    }
}
