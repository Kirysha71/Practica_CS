using System;
using System.Collections.Generic;
using System.Text;

namespace Task2
{
    public class DocumentFileWriter
    {
        public void WriteAndProtect(Document document)
        {
            File.WriteAllText("file.data", $"{document.Title}\n{document.Content}");
            File.SetAttributes("file.data", FileAttributes.ReadOnly);
        }
    }
}
