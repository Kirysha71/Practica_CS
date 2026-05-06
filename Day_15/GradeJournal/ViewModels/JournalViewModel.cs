using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Text;
using System.Windows;
using System.Windows.Input;
using GradeJournal.Models;
using GradeJournal.Services;

namespace GradeJournal.ViewModels
{
    public class JournalViewModel : INotifyPropertyChanged
    {
        private readonly JournalService _service;
        private StudentModel _selectedStudent;
        private bool _isLoading;
        private double _progressValue;

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

        public double ProgressValue
        {
            get => _progressValue;
            set { _progressValue = value; OnPropertyChanged(); }
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
        public ICommand AddStudentCommand { get; }
        public ICommand DeleteStudentCommand { get; }
        public ICommand AddGradeCommand { get; }
        public ICommand ExportCommand { get; }

        public JournalViewModel()
        {
            _service = new JournalService();

            LoadCommand = new RelayCommand(async _ => await LoadData());
            AddStudentCommand = new RelayCommand(AddStudent);
            DeleteStudentCommand = new RelayCommand(DeleteStudent, _ => SelectedStudent != null);
            AddGradeCommand = new RelayCommand(AddGrade, _ => SelectedStudent != null);
            ExportCommand = new RelayCommand(ExportToExcel);
        }

        private async Task LoadData()
        {
            IsLoading = true;
            ProgressValue = 0;

            await Task.Delay(2000);
            ProgressValue = 30;

            await _service.LoadDataAsync();
            ProgressValue = 60;

            Students.Clear();
            foreach (var s in _service.Students)
            {
                Students.Add(s);
                ProgressValue += 10;
            }

            ProgressValue = 100;
            await Task.Delay(500);

            OnPropertyChanged(nameof(GroupAverage));
            IsLoading = false;
            ProgressValue = 0;
        }

        private void AddStudent(object parameter)
        {
            var newStudent = new StudentModel { FullName = "Новый Студент" };
            Students.Add(newStudent);
            SelectedStudent = newStudent;
            OnPropertyChanged(nameof(GroupAverage));
        }

        private void DeleteStudent(object parameter)
        {
            if (SelectedStudent == null)
            {
                MessageBox.Show("Выберите студента для удаления!");
                return;
            }
            var res = MessageBox.Show($"Удалить студента \"{SelectedStudent.FullName}\"?",
                "Подтверждение", MessageBoxButton.YesNo, MessageBoxImage.Question);
            if (res == MessageBoxResult.Yes)
            {
                Students.Remove(SelectedStudent);
                SelectedStudent = null;
                OnPropertyChanged(nameof(GroupAverage));
            }
        }

        private void AddGrade(object parameter)
        {
            if (SelectedStudent == null)
            {
                MessageBox.Show("Выберите студента!");
                return;
            }
            SelectedStudent.Grades.Add(new GradeModel
            { Subject = "Новый предмет", Value = 5, Comment = "" });
        }

        private void ExportToExcel(object parameter)
        {
            MessageBox.Show("Экспорт в Excel выполнен!");
        }

        public event PropertyChangedEventHandler PropertyChanged;
        protected void OnPropertyChanged([CallerMemberName] string name = null) =>
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
    }
}