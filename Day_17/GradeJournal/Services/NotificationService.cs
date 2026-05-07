using System;
using System.Collections.Generic;
using System.IO;
using System.IO.MemoryMappedFiles;
using System.Text;

namespace GradeJournal.Services
{
    public class NotificationService
    {
        private MemoryMappedFile _mmf;

        public NotificationService()
        {
            _mmf = MemoryMappedFile.CreateOrOpen("GradeJournal_Notify", 1024);
        }

        public void Send(string message)
        {
            using (var stream = _mmf.CreateViewStream())
            using (var writer = new BinaryWriter(stream))
            {
                byte[] data = Encoding.UTF8.GetBytes(message);
                writer.Write(data.Length);
                writer.Write(data);
            }
        }
    }
}
