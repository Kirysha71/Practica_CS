using System;
using System.Collections.Generic;
using System.Text;

namespace GradeJournal
{
    public class Grade
    {
        public string StudentName { get; set; }
        public string Subject { get; set; }
        public int Value { get; set; }
        public string Comment { get; set; }
        public DateTime Date { get; set; }
    }
}
