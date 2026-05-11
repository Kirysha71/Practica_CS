using System;
using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace GradeJournal.Models
{
    public class AttendanceRecord : INotifyPropertyChanged
    {
        private int _id;
        private DateTime _date;
        private bool _isPresent;
        private int _studentId;

        public int Id
        {
            get => _id;
            set { _id = value; OnPropertyChanged(); }
        }

        public DateTime Date
        {
            get => _date;
            set { _date = value; OnPropertyChanged(); }
        }

        public bool IsPresent
        {
            get => _isPresent;
            set { _isPresent = value; OnPropertyChanged(); }
        }

        public int StudentId
        {
            get => _studentId;
            set { _studentId = value; OnPropertyChanged(); }
        }

        public StudentModel Student { get; set; }

        public event PropertyChangedEventHandler PropertyChanged;
        protected void OnPropertyChanged([CallerMemberName] string name = null) =>
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
    }
}