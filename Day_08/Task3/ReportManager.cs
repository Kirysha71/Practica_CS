using System;
using System.Collections.Generic;
using System.Text;

namespace Task3
{
    public class ReportManager<T>
    {
        private readonly IReport<T> _report;

        public ReportManager(IReport<T> report)
        {
            _report = report;
        }

        public void SaveReport(string report, string filename)
        {
            File.WriteAllText(filename, report);
            Console.WriteLine($"Report saved to {filename}");
        }

        public void GenerateAndSave(T data, string filename)
        {
            string report = _report.Generate(data);
            SaveReport(report, filename);
        }
    }
}
