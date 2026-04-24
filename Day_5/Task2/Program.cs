namespace Task2
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var theaters = new Theater[]
            {
                new Theater("Великий театр", new Actor[] { new Actor("Иванов"), new Actor("Петров") }, 500, new Audience(450)),
                new Theater("Театр имени Купалы", new Actor[] { new Actor("Смирнов") }, 200, new Audience(180)),
                new Theater("Театр имени Горького", new Actor[] { new Actor("Волков"), new Actor("Новикова"), new Actor("Морозов") }, 400, new Audience(350))
            };

            foreach (var theater in theaters)
            {
                theater.PerformPlay();
            }
        }
    }
}
