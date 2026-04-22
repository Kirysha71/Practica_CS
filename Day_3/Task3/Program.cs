namespace Task3
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Product[] products = new Product[]
            {
            new ElectronicsProduct("Ноутбук", 99999.99m, 5),
            new ElectronicsProduct("Смартфон", 69999.99m, 0),
            new ClothingProduct("Футболка", 2999.99m, 10),
            new ClothingProduct("Джинсы", 7999.99m, 0),
            new ElectronicsProduct("Наушники", 19999.99m, 3)
            };

            OnlineStore store = new OnlineStore(products);

            Console.WriteLine("Товары, которых нет в наличии:");
            foreach (var product in store.GetOutOfStockProducts())
            {
                Console.WriteLine($"{product.Name} - {product.Price} byn");
            }

            Console.WriteLine("\nСамый дорогой товар:");
            Product mostExpensive = store.GetMostExpensiveProduct();
            Console.WriteLine($"{mostExpensive.Name} - {mostExpensive.Price} byn");
        }
    }
}
