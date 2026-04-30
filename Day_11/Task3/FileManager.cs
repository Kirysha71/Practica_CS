namespace Task3
{
    class FileManager
    {
        public void CopyFile(string source, string destination)
        {
            File.Copy(source, destination, true);
            Console.WriteLine($"Файл скопирован: {source} -> {destination}");
        }

        public void MoveFile(string source, string destination)
        {
            File.Move(source, destination);
            Console.WriteLine($"Файл перемещен: {source} -> {destination}");
        }
    }
}
