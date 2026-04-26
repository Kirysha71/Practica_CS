namespace Task2
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var manager = new CircularBufferManager<int>(3);

            manager.AddItem(1);
            manager.AddItem(2);
            manager.AddItem(3);

            Console.WriteLine($"Количество: {manager.Count}");
            Console.WriteLine($"Старый: {manager.GetOldest()}");
            Console.WriteLine($"Новый: {manager.GetNewest()}");
        }
    }
}
