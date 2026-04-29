namespace Task1
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var manager = DiscountManager.Instance;
            manager.SetDiscount("Ноутбук", 15);
            manager.SetDiscount("lada vesta sw cross 2025", 5);

            var manager2 = DiscountManager.Instance;

            Console.WriteLine($"Скидка на ладу: {manager2.GetDiscount("lada vesta sw cross 2025")}");
            Console.WriteLine($"Проверка на один и тот же экземпляр: {ReferenceEquals(manager, manager2)}");
        }
    }
}
