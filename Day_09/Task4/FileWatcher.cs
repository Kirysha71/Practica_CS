using System;
using System.Collections.Generic;
using System.Text;
using static System.Console;

namespace Task4
{
    class FileWatcher
    {
        private FileSystemWatcher watcher;
        private string path;

        public FileWatcher(string directoryPath)
        {
            path = directoryPath;
            watcher = new FileSystemWatcher(path);

            watcher.Created += OnCreated;
            watcher.Deleted += OnDeleted;
            watcher.Changed += OnChanged;
            watcher.Renamed += OnRenamed;

            watcher.EnableRaisingEvents = true;
            WriteLine("Наблюдение запущено");
        }

        private void OnCreated(object sender, FileSystemEventArgs e)
        {
            WriteLine($"СОЗДАН {e.Name}");
        }

        private void OnDeleted(object sender, FileSystemEventArgs e)
        {
            WriteLine($"УДАЛЕН {e.Name}");

            if (e.Name == "important.txt" || e.Name == "config.json")
            {
                string filePath = Path.Combine(path, e.Name);
                File.WriteAllText(filePath, $"Восстановлен {e.Name}");
                WriteLine($"ЗАЩИЩЕНО {e.Name} восстановлен!");
            }
        }

        private void OnChanged(object sender, FileSystemEventArgs e)
        {
            WriteLine($"ИЗМЕНЕН {e.Name}");
        }

        private void OnRenamed(object sender, RenamedEventArgs e)
        {
            WriteLine($"ПЕРЕИМЕНОВАН {e.OldName} -> {e.Name}");
        }
    }

}
