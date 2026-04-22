namespace Task1
{
    class A
    {
        public int a;
        public int b;

        public A (int a, int b)
        {
            this.a = a;
            this.b = b;
        }

        public double Calculate()
        {
            return 1.0 / a + 1.0 / Math.Sqrt(b);
        }

        public double CalculateDegree()
        {
            return Math.Pow(a, b);
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            A obj = new A(2, 9);
            Console.WriteLine(obj.Calculate());
            Console.WriteLine(obj.CalculateDegree());
        }
    }
}
