using System;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace GradeJournal.Models
{
    public class StudentModel : INotifyPropertyChanged
    {
        private int _id;
        private string _fullName;
        private ObservableCollection<GradeModel> _grades;
        private ObservableCollection<AttendanceRecord> _attendance;
        private ObservableCollection<EnrollmentModel> _enrollments;

        public int Id
        {
            get => _id;
            set { _id = value; OnPropertyChanged(); }
        }

        public string FullName
        {
            get => _fullName;
            set { _fullName = value; OnPropertyChanged(); }
        }

        public ObservableCollection<GradeModel> Grades
        {
            get => _grades;
            set { _grades = value; OnPropertyChanged(); OnPropertyChanged(nameof(AverageGrade)); }
        }

        public ObservableCollection<AttendanceRecord> Attendance
        {
            get => _attendance;
            set { _attendance = value; OnPropertyChanged(); }
        }

        public ObservableCollection<EnrollmentModel> Enrollments
        {
            get => _enrollments;
            set { _enrollments = value; OnPropertyChanged(); }
        }

        public double AverageGrade
        {
            get
            {
                if (Grades == null || Grades.Count == 0) return 0;
                double sum = 0;
                foreach (var g in Grades) sum += g.Value;
                return sum / Grades.Count;
            }
        }

        public StudentModel()
        {
            Grades = new ObservableCollection<GradeModel>();
            Attendance = new ObservableCollection<AttendanceRecord>();
            Enrollments = new ObservableCollection<EnrollmentModel>();
            Grades.CollectionChanged += (s, e) => OnPropertyChanged(nameof(AverageGrade));
        }

        public event PropertyChangedEventHandler PropertyChanged;
        protected void OnPropertyChanged([CallerMemberName] string name = null) =>
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
    }
}