using System;
using System.Collections.Generic;
using System.Text;

namespace Task1
{
    public class FileManager
    {
        public void CreateAndWrite(string path, string text)
        {
            File.WriteAllText(path, text);
            Console.WriteLine($"Файл {path} создан и записан.");
        }

        public void ReadAndPrint(string path)
        {
            if (File.Exists(path))
            {
                Console.WriteLine($"Содержимое файла: {File.ReadAllText(path)}");
            }
        }

        public void CopyFile(string source, string dest)
        {
            File.Copy(source, dest, true);
            Console.WriteLine(File.Exists(dest) ? $"Копия {dest} создана." : "Ошибка копирования.");
        }

        public void MoveFile(string source, string dest)
        {
            if (File.Exists(source))
            {
                File.Move(source, dest);
                Console.WriteLine($"Файл перемещен в {dest}");
            }
        }

        public void RenameFile(string path, string newName)
        {
            if (File.Exists(path))
            {
                string directory = Path.GetDirectoryName(path);
                string newPath = Path.Combine(directory, newName);
                File.Move(path, newPath);
                Console.WriteLine($"Файл переименован в {newName}");
            }
        }

        public void DeleteFile(string path)
        {
            try
            {
                if (File.Exists(path))
                {
                    File.Delete(path);
                    Console.WriteLine($"Файл {path} удален.");
                }
                else
                {
                    throw new FileNotFoundException("Файл для удаления не найден.");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Ошибка при удалении: {ex.Message}");
            }
        }

        public void DeleteFilesByPattern(string directory, string pattern)
        {
            string[] files = Directory.GetFiles(directory, pattern);
            foreach (string file in files)
            {
                File.Delete(file);
                Console.WriteLine($"Удален файл по шаблону: {Path.GetFileName(file)}");
            }
        }

        public void SetReadOnly(string path, bool readOnly)
        {
            if (File.Exists(path))
            {
                FileInfo info = new FileInfo(path);
                info.IsReadOnly = readOnly;
                Console.WriteLine($"Атрибут 'Только для чтения' установлен в: {readOnly}");
            }
        }
    }
}
