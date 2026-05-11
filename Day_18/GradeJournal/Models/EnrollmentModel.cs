using System;
using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace GradeJournal.Models
{
    public class EnrollmentModel : INotifyPropertyChanged
    {
        private int _id;
        private int _studentId;
        private int _courseId;
        private DateTime _enrollmentDate;
        private string _status;

        public int Id
        {
            get => _id;
            set { _id = value; OnPropertyChanged(); }
        }

        public int StudentId
        {
            get => _studentId;
            set { _studentId = value; OnPropertyChanged(); }
        }

        public int CourseId
        {
            get => _courseId;
            set { _courseId = value; OnPropertyChanged(); }
        }

        public DateTime EnrollmentDate
        {
            get => _enrollmentDate;
            set { _enrollmentDate = value; OnPropertyChanged(); }
        }

        public string Status
        {
            get => _status;
            set { _status = value; OnPropertyChanged(); }
        }

        public StudentModel Student { get; set; }
        public CourseModel Course { get; set; }

        public event PropertyChangedEventHandler PropertyChanged;
        protected void OnPropertyChanged([CallerMemberName] string name = null) =>
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
    }
}