namespace Task2
{
    internal class Program
    {
        static void Main(string[] args)
        {
            try
            {
                new DataSerializer().SerializeData(new object());
            }
            catch (SerializationOperationException ex)
            {
                Console.WriteLine($"Caught: {ex.Message}");
            }
        }
    }
}
