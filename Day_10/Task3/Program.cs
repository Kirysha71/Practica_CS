namespace Task3
{

    public class Program
    {
        public static void Main()
        {
            var manager = new PromotionManager();

            var loyal1 = new LoyalCustomer("Кирюшка");
            var loyal2 = new LoyalCustomer("Павел");
            var regular1 = new RegularCustomer("Патрик");

            manager.Subscribe(loyal1);
            manager.Subscribe(loyal2);
            manager.Subscribe(regular1);

            manager.AddPromotion("Скидка 10% на всё");
            manager.AddPromotion("Бесплатная доставка при заказе от 50$");
        }
    }
}
