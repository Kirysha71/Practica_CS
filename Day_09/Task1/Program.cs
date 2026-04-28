namespace Task1
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string myDir = "D:\\programms\\Practica_CS\\Day_09\\Task1";
            string fileName = "fedosik.ks";
            string filePath = Path.Combine(myDir, fileName);

            FileManager fm = new FileManager();
            FileInfoProvider fp = new FileInfoProvider();

            fm.CreateAndWrite(filePath, "А что вы делаете в моем файле?");
            fm.ReadAndPrint(filePath);

            fp.DisplayFileInfo(filePath);
            fp.CheckPermissions(filePath);

            string copyPath = filePath + ".copy";
            fm.CopyFile(filePath, copyPath);
            fp.CompareFilesBySize(filePath, copyPath);

            fm.RenameFile(copyPath, "fedosik_new.io");

            Console.WriteLine("Все файлы в директории:");
            string[] allFiles = Directory.GetFiles(myDir);
            foreach (var f in allFiles) Console.WriteLine(Path.GetFileName(f));

            fm.SetReadOnly(filePath, true);
            try { fm.CreateAndWrite(filePath, "Новые данные"); }
            catch (Exception ex) { Console.WriteLine($"Блокировка сработала: {ex.Message}"); }
            fm.SetReadOnly(filePath, false);

            fm.DeleteFilesByPattern(myDir, "*.ks");
            fm.DeleteFile("fedosik_new.io");
        }
    }
}
