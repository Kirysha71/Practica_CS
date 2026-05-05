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
        private ObservableCollection<Grade> _grades;
        private Grade _selectedGrade;

        public ObservableCollection<Grade> Grades
        {
            get => _grades;
            set { _grades = value; OnPropertyChanged(nameof(Grades)); }
        }

        public Grade SelectedGrade
        {
            get => _selectedGrade;
            set { _selectedGrade = value; OnPropertyChanged(nameof(SelectedGrade)); }
        }

        public ICommand AddGradeCommand { get; }
        public ICommand EditGradeCommand { get; }
        public ICommand DeleteGradeCommand { get; }

        public MainWindow()
        {
            InitializeComponent();

            Grades = new ObservableCollection<Grade>
            {
                new Grade { StudentName = "Павлик", Subject = "С#", Value = 3, Comment = "Мог бы  и выучить массивы", Date = DateTime.Now },
                new Grade { StudentName = "Асылбек", Subject = "С#", Value = 5, Comment = "Хорошо", Date = DateTime.Now }
            };

            dgGrades.ItemsSource = Grades;
            dgGrades.SelectionChanged += (s, e) => SelectedGrade = dgGrades.SelectedItem as Grade;

            AddGradeCommand = new RelayCommand(AddGrade);
            EditGradeCommand = new RelayCommand(EditGrade, parameter => SelectedGrade != null);
            DeleteGradeCommand = new RelayCommand(DeleteGrade, parameter => SelectedGrade != null);

            DataContext = this;
        }

        private void AddGrade(object parameter)
        {
            var window = new AddEditGradeWindow();
            window.Owner = this;

            if (window.ShowDialog() == true)
            {
                Grades.Add(window.GradeData);
            }
        }

        private void EditGrade(object parameter)
        {
            if (SelectedGrade == null)
            {
                MessageBox.Show("Выберите оценку для редактирования!", "Внимание",
                    MessageBoxButton.OK, MessageBoxImage.Information);
                return;
            }

            var window = new AddEditGradeWindow(SelectedGrade);
            window.Owner = this;

            if (window.ShowDialog() == true)
            {
                int index = Grades.IndexOf(SelectedGrade);
                Grades.RemoveAt(index);
                Grades.Insert(index, window.GradeData);
                dgGrades.SelectedItem = window.GradeData;
            }
        }

        private void DeleteGrade(object parameter)
        {
            if (SelectedGrade == null)
            {
                MessageBox.Show("Выберите оценку для удаления!", "Внимание",
                    MessageBoxButton.OK, MessageBoxImage.Information);
                return;
            }

            var result = MessageBox.Show($"Удалить оценку студента \"{SelectedGrade.StudentName}\"?",
                "Подтверждение", MessageBoxButton.YesNo, MessageBoxImage.Question);

            if (result == MessageBoxResult.Yes)
            {
                Grades.Remove(SelectedGrade);
            }
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