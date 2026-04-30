namespace Task1
{
    public class Smartphone : IElectronicDevice
    {
        public void TurnOn() => Console.WriteLine("Смартфон включён. Разблокировка экрана и запуск приложений...");
    }
}
