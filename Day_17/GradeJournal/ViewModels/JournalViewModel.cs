using System;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;
using GradeJournal.Models;
using GradeJournal.Services;

namespace GradeJournal.ViewModels
{
    public class JournalViewModel : INotifyPropertyChanged
    {
        private readonly UserModel _user;
        private StudentModel _selectedStudent;
        private bool _isLoading;
        private double _progress;

        public ObservableCollection<StudentModel> Students { get; } = new ObservableCollection<StudentModel>();

        public StudentModel SelectedStudent
        {
            get => _selectedStudent;
            set
            {
                _selectedStudent = value;
                OnPropertyChanged();
                CommandManager.InvalidateRequerySuggested();
            }
        }

        public bool IsLoading
        {
            get => _isLoading;
            set { _isLoading = value; OnPropertyChanged(); }
        }

        public double Progress
        {
            get => _progress;
            set { _progress = value; OnPropertyChanged(); }
        }

        public int LowPerformersCount
        {
            get
            {
                int count = 0;
                foreach (var s in Students)
                    if (s.AverageGrade < 3.5) count++;
                return count;
            }
        }

        public double GroupAverage
        {
            get
            {
                if (Students.Count == 0) return 0;
                double sum = 0;
                foreach (var s in Students) sum += s.AverageGrade;
                return sum / Students.Count;
            }
        }

        public ICommand LoadCommand { get; }
        public ICommand SaveCommand { get; }
        public ICommand AddCommand { get; }
        public ICommand EditCommand { get; }
        public ICommand DeleteCommand { get; }

        public JournalViewModel(UserModel user)
        {
            _user = user;
            LoadCommand = new RelayCommand(_ => LoadDataAsync());
            SaveCommand = new RelayCommand(_ => SaveDataAsync());
            AddCommand = new RelayCommand(_ => AddStudent());
            EditCommand = new RelayCommand(_ => EditStudent(), _ => SelectedStudent != null);
            DeleteCommand = new RelayCommand(_ => DeleteStudent(), _ => SelectedStudent != null);
        }

        private async void LoadDataAsync()
        {
            IsLoading = true;
            Progress = 0;
            await Task.Delay(2000);
            Progress = 50;

            var data = await DataService.LoadJournalAsync();
            Students.Clear();
            foreach (var s in data)
            {
                Students.Add(s);
                Progress += 50.0 / data.Count;
            }

            Progress = 100;
            IsLoading = false;
            OnPropertyChanged(nameof(GroupAverage));
            OnPropertyChanged(nameof(LowPerformersCount));
        }

        private async void SaveDataAsync()
        {
            await DataService.SaveJournalAsync(Students);
            MessageBox.Show("Данные сохранены!", "Информация", MessageBoxButton.OK, MessageBoxImage.Information);
        }

        private void AddStudent()
        {
            Students.Add(new StudentModel { FullName = "Новый студент" });
            OnPropertyChanged(nameof(GroupAverage));
            OnPropertyChanged(nameof(LowPerformersCount));
        }

        private void EditStudent()
        {
            if (SelectedStudent == null)
            {
                MessageBox.Show("Выберите студента для редактирования (кликните на карточку)!",
                    "Внимание", MessageBoxButton.OK, MessageBoxImage.Warning);
                return;
            }

            var newName = Microsoft.VisualBasic.Interaction.InputBox(
                "Введите новое имя студента:",
                "Редактирование студента",
                SelectedStudent.FullName);

            if (!string.IsNullOrWhiteSpace(newName))
            {
                SelectedStudent.FullName = newName;
                MessageBox.Show($"Студент \"{SelectedStudent.FullName}\" обновлен!", "Успех",
                    MessageBoxButton.OK, MessageBoxImage.Information);
            }
        }

        private void DeleteStudent()
        {
            if (SelectedStudent == null)
            {
                MessageBox.Show("Выберите студента для удаления!", "Внимание",
                    MessageBoxButton.OK, MessageBoxImage.Warning);
                return;
            }

            if (MessageBox.Show($"Удалить студента \"{SelectedStudent.FullName}\"?",
                "Подтверждение", MessageBoxButton.YesNo, MessageBoxImage.Question) == MessageBoxResult.Yes)
            {
                Students.Remove(SelectedStudent);
                SelectedStudent = null;
                OnPropertyChanged(nameof(GroupAverage));
                OnPropertyChanged(nameof(LowPerformersCount));
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;
        protected void OnPropertyChanged([CallerMemberName] string name = null) =>
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
    }
}