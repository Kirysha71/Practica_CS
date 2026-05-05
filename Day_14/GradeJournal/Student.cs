using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Text;

namespace GradeJournal
{
    public class Student : INotifyPropertyChanged
    {
        private string _name;
        private ObservableCollection<GradeRecord> _grades;
        private ObservableCollection<AttendanceRecord> _attendance;

        public string Name
        {
            get => _name;
            set { _name = value; OnPropertyChanged(); }
        }

        public ObservableCollection<GradeRecord> Grades
        {
            get => _grades;
            set
            {
                _grades = value;
                OnPropertyChanged();
                OnPropertyChanged(nameof(AverageGrade));
            }
        }

        public ObservableCollection<AttendanceRecord> Attendance
        {
            get => _attendance;
            set { _attendance = value; OnPropertyChanged(); }
        }

        public double AverageGrade
        {
            get
            {
                if (Grades == null || Grades.Count == 0)
                    return 0;

                int sum = 0;
                int count = 0;

                foreach (var grade in Grades)
                {
                    if (grade.Value > 0)
                    {
                        sum += grade.Value;
                        count++;
                    }
                }

                if (count == 0)
                    return 0;

                return (double)sum / count;
            }
        }

        public Student()
        {
            Grades = new ObservableCollection<GradeRecord>();
            Attendance = new ObservableCollection<AttendanceRecord>();

            Grades.CollectionChanged += (s, e) => OnPropertyChanged(nameof(AverageGrade));
        }

        public event PropertyChangedEventHandler PropertyChanged;
        protected void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
