namespace Task1
{

    class Program
    {
        static void Main()
        {
            ElectronicDeviceFactory factory;

            factory = new LaptopFactory();
            factory.ProduceAndTurnOn();

            factory = new TabletFactory();
            factory.ProduceAndTurnOn();

            factory = new SmartphoneFactory();
            factory.ProduceAndTurnOn();
        }
    }
}
