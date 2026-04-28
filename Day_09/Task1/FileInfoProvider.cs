using System;
using System.Collections.Generic;
using System.Text;

namespace Task1
{
    public class FileInfoProvider
    {
        public void DisplayFileInfo(string path)
        {
            if (File.Exists(path))
            {
                FileInfo info = new FileInfo(path);
                Console.WriteLine($"Информация о файле: {info.Name}");
                Console.WriteLine($"Размер: {info.Length} байт");
                Console.WriteLine($"Создан: {info.CreationTime}");
                Console.WriteLine($"Изменен: {info.LastWriteTime}");
            }
        }

        public void CompareFilesBySize(string path1, string path2)
        {
            if (File.Exists(path1) && File.Exists(path2))
            {
                long size1 = new FileInfo(path1).Length;
                long size2 = new FileInfo(path2).Length;
                Console.WriteLine(size1 == size2 ? "Файлы равны по размеру" :
                    size1 > size2 ? "Первый файл больше" : "Второй файл больше");
            }
        }

        public void CheckPermissions(string path)
        {
            if (File.Exists(path))
            {
                FileInfo info = new FileInfo(path);
                Console.WriteLine($"Только для чтения: {info.IsReadOnly}");
            }
        }
    }
}
