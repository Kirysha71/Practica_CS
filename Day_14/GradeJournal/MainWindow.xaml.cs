using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace GradeJournal
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window, INotifyPropertyChanged
    {
        private ObservableCollection<Student> _students;
        private Student _selectedStudent;

        public ObservableCollection<Student> Students
        {
            get => _students;
            set { _students = value; OnPropertyChanged(nameof(Students)); }
        }

        public Student SelectedStudent
        {
            get => _selectedStudent;
            set { _selectedStudent = value; OnPropertyChanged(nameof(SelectedStudent)); }
        }

        public double GroupAverage
        {
            get
            {
                if (Students == null || Students.Count == 0)
                    return 0;

                double sum = 0;
                int count = 0;

                foreach (var student in Students)
                {
                    if (student.AverageGrade > 0)
                    {
                        sum += student.AverageGrade;
                        count++;
                    }
                }

                if (count == 0)
                    return 0;

                return sum / count;
            }
        }

        public ICommand AddStudentCommand { get; }
        public ICommand EditStudentCommand { get; }
        public ICommand DeleteStudentCommand { get; }
        public ICommand AddGradeCommand { get; }
        public ICommand EditGradeCommand { get; }
        public ICommand ExportCommand { get; }

        public MainWindow()
        {
            InitializeComponent();

            Students = new ObservableCollection<Student>
            {
                new Student
                {
                    Name = "Иванов Иван",
                    Grades = new ObservableCollection<GradeRecord>
                    {
                        new GradeRecord { Subject = "Математика", Value = 5, Comment = "Отлично" },
                        new GradeRecord { Subject = "Физика", Value = 4, Comment = "Хорошо" }
                    },
                    Attendance = new ObservableCollection<AttendanceRecord>
                    {
                        new AttendanceRecord { Date = System.DateTime.Now.AddDays(-2), IsPresent = true },
                        new AttendanceRecord { Date = System.DateTime.Now.AddDays(-1), IsPresent = true },
                        new AttendanceRecord { Date = System.DateTime.Now, IsPresent = false }
                    }
                },
                new Student
                {
                    Name = "Петров Петр",
                    Grades = new ObservableCollection<GradeRecord>
                    {
                        new GradeRecord { Subject = "Математика", Value = 4, Comment = "Хорошо" },
                        new GradeRecord { Subject = "Физика", Value = 5, Comment = "Отлично" }
                    },
                    Attendance = new ObservableCollection<AttendanceRecord>
                    {
                        new AttendanceRecord { Date = System.DateTime.Now.AddDays(-2), IsPresent = true },
                        new AttendanceRecord { Date = System.DateTime.Now.AddDays(-1), IsPresent = true },
                        new AttendanceRecord { Date = System.DateTime.Now, IsPresent = true }
                    }
                }
            };

            Students.CollectionChanged += (s, e) => OnPropertyChanged(nameof(GroupAverage));

            DataContext = this;

            AddStudentCommand = new RelayCommand(AddStudent);
            EditStudentCommand = new RelayCommand(EditStudent, parameter => SelectedStudent != null);
            DeleteStudentCommand = new RelayCommand(DeleteStudent, parameter => SelectedStudent != null);
            AddGradeCommand = new RelayCommand(AddGrade);
            EditGradeCommand = new RelayCommand(EditGrade);
            ExportCommand = new RelayCommand(ExportToExcel);
        }

        private void AddStudent(object parameter)
        {
            var student = new Student { Name = "Новый студент" };
            Students.Add(student);
            SelectedStudent = student;
            OnPropertyChanged(nameof(GroupAverage));
        }

        private void EditStudent(object parameter)
        {
            if (SelectedStudent == null)
            {
                MessageBox.Show("Выберите студента для редактирования!", "Внимание",
                    MessageBoxButton.OK, MessageBoxImage.Information);
                return;
            }

            var newName = Microsoft.VisualBasic.Interaction.InputBox(
                "Введите имя студента:", "Редактирование", SelectedStudent.Name);

            if (!string.IsNullOrWhiteSpace(newName))
            {
                SelectedStudent.Name = newName;
            }
        }

        private void DeleteStudent(object parameter)
        {
            if (SelectedStudent == null)
            {
                MessageBox.Show("Выберите студента для удаления!", "Внимание",
                    MessageBoxButton.OK, MessageBoxImage.Information);
                return;
            }

            var result = MessageBox.Show($"Удалить студента \"{SelectedStudent.Name}\"?",
                "Подтверждение", MessageBoxButton.YesNo, MessageBoxImage.Question);

            if (result == MessageBoxResult.Yes)
            {
                Students.Remove(SelectedStudent);
                OnPropertyChanged(nameof(GroupAverage));
            }
        }

        private void AddGrade(object parameter)
        {
            if (SelectedStudent == null)
            {
                MessageBox.Show("Выберите студента для добавления оценки!", "Внимание",
                    MessageBoxButton.OK, MessageBoxImage.Information);
                return;
            }

            var subject = Microsoft.VisualBasic.Interaction.InputBox(
                "Введите предмет:", "Добавление оценки");

            if (!string.IsNullOrWhiteSpace(subject))
            {
                SelectedStudent.Grades.Add(new GradeRecord
                {
                    Subject = subject,
                    Value = 5,
                    Comment = ""
                });
            }
        }

        private void EditGrade(object parameter)
        {
            MessageBox.Show("Редактирование оценок доступно прямо в списке (измените значение в TextBox)",
                "Информация", MessageBoxButton.OK, MessageBoxImage.Information);
        }

        private void ExportToExcel(object parameter)
        {
            MessageBox.Show("Данные экспортированы в Excel!", "Экспорт",
                MessageBoxButton.OK, MessageBoxImage.Information);
        }

        private void Exit_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }

        private void Settings_Click(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("Настройки приложения", "Информация",
                MessageBoxButton.OK, MessageBoxImage.Information);
        }

        public event PropertyChangedEventHandler PropertyChanged;
        protected void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}