using static System.Console;

namespace Task1
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var cart = new ShoppingCart();

            cart.Add(new Product { Id = 1, Name = "Яблоко", Price = 1.5m });
            cart.Add(new Product { Id = 2, Name = "Банан", Price = 0.8m });
            cart.Add(new Product { Id = 3, Name = "Апельсин", Price = 2.0m });

            WriteLine($"Общее количество: {cart.Count}");

            var product = cart.Get(1);
            WriteLine($"{product.Name}: ${product.Price}");

            cart.Remove(2);
            WriteLine($"После удаления: {cart.Count} предметов");
        }
    }
}