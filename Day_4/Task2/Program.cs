using static System.Console;

namespace Task2
{
    internal class Program
    {
        static void SortDec(ref int A, ref int B, ref int C)
        {
            int temp;

            if (A < B) {temp = A;A = B;B = temp; }
            if (B < C) {temp = B;B = C;C = temp; }
            if (A < B) {temp = A;A = B;B = temp; }
        }


        static void Main(string[] args)
        {
            int A1 = 5, B1 = 12, C1 = 8;
            int A2 = 3, B2 = 1, C2 = 9;


            WriteLine($"До: A1={A1}, B1={B1}, C1={C1}");
            SortDec(ref A1, ref B1, ref C1);
            WriteLine($"После: A1={A1}, B1={B1}, C1={C1}");

            WriteLine($"До: A2={A2}, B2={B2}, C2={C2}");
            SortDec(ref A2, ref B2, ref C2);
            WriteLine($"После: A2={A2}, B2={B2}, C2={C2}");
        }
    }
}
