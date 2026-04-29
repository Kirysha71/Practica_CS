namespace Task3
{
    public class RegularCustomer : ICustomer
    {
        private string _name;

        public RegularCustomer(string name)
        {
            _name = name;
        }

        public void Notify(string promotion)
        {
            Console.WriteLine($"Обычный клиент {_name}: {promotion}");
        }
    }
}
