namespace Task3
{
    public class PromotionManager
    {
        private List<ICustomer> _customers = new List<ICustomer>();

        public void Subscribe(ICustomer customer)
        {
            _customers.Add(customer);
        }

        public void AddPromotion(string promotion)
        {
            Console.WriteLine($"Новая акция: {promotion}");
            foreach (var customer in _customers)
            {
                customer.Notify(promotion);
            }
        }
    }
}
