namespace Task3
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var report = new TextReport<string>();
            var manager = new ReportManager<string>(report);

            manager.GenerateAndSave("Sales data for 2024", "report.txt");
        }
    }
}
