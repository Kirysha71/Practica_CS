using static System.Runtime.InteropServices.JavaScript.JSType;

namespace Task3
{
    internal class Program
    {
        static int FindIndex(int[] mas,  int value)
        {
            return FindRekursia(mas, value, 0);
        }

        static int FindRekursia(int[] mas, int value, int index)
        {
            if(index >= mas.Length)
            return -1;

            if (mas[index] == value)
                return index;

            return FindRekursia(mas, value, index + 1);
        }

        static void Main(string[] args)
        {
            int[] mas = { 1, 2, 3, 4, 7, 13, 10, 9 };

            Console.WriteLine($"Данный элемент по индексу = {FindIndex(mas, 9)}");
        }
    }
}
