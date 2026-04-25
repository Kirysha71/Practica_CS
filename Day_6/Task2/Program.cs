using static System.Console;

namespace Task2
{
    public delegate void ConfigSetter(string config);
    public class Program
    {
        public static void SetConfiguration(string name, ConfigSetter setter)
        {
            WriteLine($"Настройка: {name}");
            setter("Applied");
            WriteLine();
        }

        public static void SetDatabaseConfig(string config)
        {
            WriteLine($"Database: {config}");
        }

        public static void SetCacheConfig(string config)
        {
            WriteLine($"Cache: {config}");
        }
        static void Main(string[] args)
        {
            SetConfiguration("Database", SetDatabaseConfig);
            SetConfiguration("Cache", SetCacheConfig);
        }
    }
}
