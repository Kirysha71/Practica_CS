namespace Task5
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Tree tree = new Tree { Name = "Дуб", Height = 15 };
            Flower flower = new Flower { Name = "Роза", Color = "Красный" };

            tree.Grow();
            tree.DisplayInfo();

            Console.WriteLine();

            flower.Grow();
            flower.DisplayInfo();
        }
    }
}
