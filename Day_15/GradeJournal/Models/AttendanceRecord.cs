using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Text;

namespace GradeJournal.Models
{
    public class AttendanceRecord : INotifyPropertyChanged
    {
        private DateTime _date;
        private bool _isPresent;

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

        public event PropertyChangedEventHandler PropertyChanged;
        protected void OnPropertyChanged([CallerMemberName] string name = null) =>
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
    }
}
