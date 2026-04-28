namespace Task2
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var doc = new Document { Title = "Анекдот", Content = "Никогда не выявляйте в программе ошибки, если не знаете, что с ними дальше делать." };
            var writer = new DocumentFileWriter();
            writer.WriteAndProtect(doc);

            Console.WriteLine("Файл записан и защищен");
        }
    }
}
