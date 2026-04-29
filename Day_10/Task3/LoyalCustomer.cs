namespace Task3
{
    public class LoyalCustomer : ICustomer
    {
        private string _name;

        public LoyalCustomer(string name)
        {
            _name = name;
        }

        public void Notify(string promotion)
        {
            Console.WriteLine($"Постоянный клиент {_name}: {promotion}");
        }
    }
}
