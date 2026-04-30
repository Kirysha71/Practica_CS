namespace Task3
{

    class Program
    {
        static void Main()
        {
            var fileManager = new FileManager();
            var invoker = new FileOperationInvoker();

            invoker.AddCommand(new CopyFileCommand(fileManager, "source.txt", "copy.txt"));
            invoker.AddCommand(new MoveFileCommand(fileManager, "copy.txt", "moved.txt"));

            invoker.ExecuteAll();
        }
    }
}
