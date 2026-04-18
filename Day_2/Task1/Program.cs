namespace Task1
{
    internal class Program
    {
        static void Main(string[] args)
        {
            double[] arr = { 1.2, 0.5, 2.0, 3, 0.7, 3.2, 5 };

            Console.WriteLine("Элементы, удовлетворяющие условию 0 < xi < 3.2: ");

            for(int i = 0; i < arr.Length; i++)
            {
                if (arr[i] > 0 && arr[i] < 3.2)
                {
                    Console.WriteLine($"Индекс: {i}, Значение: {arr[i]}");
                }
            }
        }
    }
}
