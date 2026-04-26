namespace Task3
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var server = new ServerConnection();

            try
            {
                server.Connect(5);
                server.Connect(15);
            }
            catch (TooManyConnectionsException ex)
            {
                Console.WriteLine($"Ошибка: {ex.Message}");
            }
        }
    }
}
