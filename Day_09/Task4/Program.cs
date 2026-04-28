namespace Task4
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string testDir = "watch_folder";

            if (!Directory.Exists(testDir))
                Directory.CreateDirectory(testDir);

            File.WriteAllText(Path.Combine(testDir, "important.txt"), "Как у вас дела?");
            File.WriteAllText(Path.Combine(testDir, "config.json"), "{\"setting\": true}");

            var watcher = new FileWatcher(testDir);

            Console.WriteLine("\nПопробуйте удалить important.txt или config.json");
            Console.WriteLine("Нажмите Enter для выхода\n");
            Console.ReadLine();
        }
    }
}
