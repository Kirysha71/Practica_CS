using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Text;

namespace GradeJournal
{
    public class GradeRecord : INotifyPropertyChanged
    {
        private string _subject;
        private int _value;
        private string _comment;

        public string Subject
        {
            get => _subject;
            set { _subject = value; OnPropertyChanged(); }
        }

        public int Value
        {
            get => _value;
            set { _value = value; OnPropertyChanged(); }
        }

        public string Comment
        {
            get => _comment;
            set { _comment = value; OnPropertyChanged(); }
        }

        public event PropertyChangedEventHandler PropertyChanged;
        protected void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
