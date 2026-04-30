namespace Task1
{
    public abstract class ElectronicDeviceFactory
    {
        public abstract IElectronicDevice CreateDevice();

        public void ProduceAndTurnOn()
        {
            var device = CreateDevice();
            Console.WriteLine($" Фабрика создала устройство: {device.GetType().Name}");
            device.TurnOn();
            Console.WriteLine();
        }
    }
}
