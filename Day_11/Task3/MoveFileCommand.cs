namespace Task3
{
    class MoveFileCommand : ICommand
    {
        private readonly FileManager _fileManager;
        private readonly string _source;
        private readonly string _destination;

        public MoveFileCommand(FileManager fileManager, string source, string destination)
        {
            _fileManager = fileManager;
            _source = source;
            _destination = destination;
        }

        public void Execute() => _fileManager.MoveFile(_source, _destination);
    }
}
