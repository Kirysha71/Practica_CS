using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace GradeJournal.Models
{
    public class CourseModel : INotifyPropertyChanged
    {
        private int _id;
        private string _name;
        private ObservableCollection<EnrollmentModel> _enrollments;

        public int Id
        {
            get => _id;
            set { _id = value; OnPropertyChanged(); }
        }

        public string Name
        {
            get => _name;
            set { _name = value; OnPropertyChanged(); }
        }

        public ObservableCollection<EnrollmentModel> Enrollments
        {
            get => _enrollments;
            set { _enrollments = value; OnPropertyChanged(); }
        }

        public CourseModel()
        {
            Enrollments = new ObservableCollection<EnrollmentModel>();
        }

        public event PropertyChangedEventHandler PropertyChanged;
        protected void OnPropertyChanged([CallerMemberName] string name = null) =>
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
    }
}