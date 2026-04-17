using static System.Console;

namespace Task1
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Write("Введите число а: ");
            int a = int.Parse(ReadLine());

            Write("Введите число б: ");
            int b = int.Parse(ReadLine());

            WriteLine("Выберите операци, которую хотите выполнить (+, -, *, /)");
            char op = Convert.ToChar(ReadLine());


            switch (op)
            {
                case '+': WriteLine(a + b); break;
                case '-': WriteLine(a - b); break;
                case '*': WriteLine(a * b); break;
                case '/': WriteLine(a / b); break;
            }
        }
    }
}
