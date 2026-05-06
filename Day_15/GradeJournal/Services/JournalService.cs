using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using GradeJournal.Models;

namespace GradeJournal.Services
{
    public class JournalService
    {
        public ObservableCollection<StudentModel> Students { get; } = new ObservableCollection<StudentModel>();

        public async Task LoadDataAsync()
        {
            await Task.Delay(1000);
            Students.Clear();

            var s1 = new StudentModel { FullName = "Киря" };
            s1.Grades.Add(new GradeModel { Subject = "СИшарп", Value = 5, Comment = "Отлично" });
            s1.Grades.Add(new GradeModel { Subject = "псиип", Value = 4, Comment = "Хорошо" });

            s1.Attendance.Add(new AttendanceRecord { Date = new DateTime(2026, 5, 3), IsPresent = true });
            s1.Attendance.Add(new AttendanceRecord { Date = new DateTime(2026, 5, 4), IsPresent = true });
            s1.Attendance.Add(new AttendanceRecord { Date = new DateTime(2026, 5, 5), IsPresent = false });

            var s2 = new StudentModel { FullName = "Артем" };
            s2.Grades.Add(new GradeModel { Subject = "Пооги", Value = 5, Comment = "Хорошо" });
            s2.Grades.Add(new GradeModel { Subject = "ПСИИП", Value = 5, Comment = "Отлично" });

            s2.Attendance.Add(new AttendanceRecord { Date = new DateTime(2026, 5, 3), IsPresent = true });
            s2.Attendance.Add(new AttendanceRecord { Date = new DateTime(2026, 5, 4), IsPresent = true });
            s2.Attendance.Add(new AttendanceRecord { Date = new DateTime(2026, 5, 5), IsPresent = true });

            Students.Add(s1);
            Students.Add(s2);
        }
    }
}
