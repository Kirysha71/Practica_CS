namespace Task1
{
    internal class Program
    {
        static void Main(string[] args)
        {
            CelestialBody[] celestialBodies = new CelestialBody[]
            {
                new Planet("Земля", 1.0),
                new Star("Солнце", 5500),
                new Asteroid("церера", 940)
            };

            Console.WriteLine("Объекты солнечной системы");

            foreach (var body in celestialBodies)
            {
                Console.WriteLine(body.GetInfo());
            }
        }
    }
}
