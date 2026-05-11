using System;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;
using GradeJournal.Data;
using GradeJournal.Data.Repositories;
using GradeJournal.Models;
using GradeJournal.Services;

namespace GradeJournal.ViewModels
{
    public class JournalViewModel : INotifyPropertyChanged
    {
        private readonly ApplicationDbContext _context;
        private readonly StudentRepository _studentRepository;
        private readonly EnrollmentRepository _enrollmentRepository;
        private readonly CourseRepository _courseRepository;

        private StudentModel _selectedStudent;
        private EnrollmentModel _selectedEnrollment;
        private bool _isLoading;
        private double _progress;

        public ObservableCollection<StudentModel> Students { get; } = new ObservableCollection<StudentModel>();
        public ObservableCollection<EnrollmentModel> Enrollments { get; } = new ObservableCollection<EnrollmentModel>();
        public ObservableCollection<CourseModel> Courses { get; } = new ObservableCollection<CourseModel>();

        public StudentModel SelectedStudent
        {
            get => _selectedStudent;
            set { _selectedStudent = value; OnPropertyChanged(); CommandManager.InvalidateRequerySuggested(); }
        }

        public EnrollmentModel SelectedEnrollment
        {
            get => _selectedEnrollment;
            set { _selectedEnrollment = value; OnPropertyChanged(); }
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

        public ICommand LoadCommand { get; }
        public ICommand SaveCommand { get; }
        public ICommand AddStudentCommand { get; }
        public ICommand EditStudentCommand { get; }
        public ICommand DeleteStudentCommand { get; }
        public ICommand AddEnrollmentCommand { get; }
        public ICommand AddGradeCommand { get; }

        public JournalViewModel()
        {
            _context = new ApplicationDbContext();
            _studentRepository = new StudentRepository(_context);
            _enrollmentRepository = new EnrollmentRepository(_context);
            _courseRepository = new CourseRepository(_context);

            LoadCommand = new RelayCommand(async _ => await LoadDataAsync());
            SaveCommand = new RelayCommand(async _ => await SaveAllAsync());
            AddStudentCommand = new RelayCommand(async _ => await AddStudentAsync());
            EditStudentCommand = new RelayCommand(async _ => await EditStudentAsync(), _ => SelectedStudent != null);
            DeleteStudentCommand = new RelayCommand(async _ => await DeleteStudentAsync(), _ => SelectedStudent != null);
            AddEnrollmentCommand = new RelayCommand(async _ => await AddEnrollmentAsync());
            AddGradeCommand = new RelayCommand(async _ => await AddGradeAsync(), _ => SelectedStudent != null);
        }

        private async Task LoadDataAsync()
        {
            IsLoading = true;
            Progress = 0;

            await _context.Database.EnsureCreatedAsync();
            Progress = 20;

            var students = await _studentRepository.GetAllAsync();
            var enrollments = await _enrollmentRepository.GetAllAsync();
            var courses = await _courseRepository.GetAllAsync();
            Progress = 60;

            Students.Clear();
            foreach (var s in students)
            {
                Students.Add(s);
                Progress += 10;
            }

            Enrollments.Clear();
            foreach (var e in enrollments)
                Enrollments.Add(e);

            Courses.Clear();
            foreach (var c in courses)
                Courses.Add(c);

            Progress = 100;
            IsLoading = false;
            OnPropertyChanged(nameof(GroupAverage));
            OnPropertyChanged(nameof(LowPerformersCount));

            if (Students.Count == 0)
                await CreateTestDataAsync();
        }

        private async Task SaveAllAsync()
        {
            try
            {
                await _context.SaveChangesAsync();
                MessageBox.Show("Данные сохранены в базу данных!", "Сохранение", MessageBoxButton.OK, MessageBoxImage.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ошибка: {ex.Message}", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private async Task AddStudentAsync()
        {
            var newStudent = new StudentModel
            {
                FullName = "Новый студент",
                Enrollments = new ObservableCollection<EnrollmentModel>(),
                Grades = new ObservableCollection<GradeModel>(),
                Attendance = new ObservableCollection<AttendanceRecord>()
            };

            await _studentRepository.AddAsync(newStudent);
            await _context.SaveChangesAsync();

            Students.Add(newStudent);
            SelectedStudent = newStudent;
            OnPropertyChanged(nameof(GroupAverage));
            OnPropertyChanged(nameof(LowPerformersCount));
        }

        private async Task EditStudentAsync()
        {
            if (SelectedStudent == null) return;

            var newName = Microsoft.VisualBasic.Interaction.InputBox(
                "Введите имя:", "Редактирование", SelectedStudent.FullName);

            if (!string.IsNullOrWhiteSpace(newName))
            {
                SelectedStudent.FullName = newName;
                _studentRepository.Update(SelectedStudent);
                await _context.SaveChangesAsync();
            }
        }

        private async Task DeleteStudentAsync()
        {
            if (SelectedStudent == null) return;

            if (MessageBox.Show($"Удалить {SelectedStudent.FullName}?", "Подтверждение",
                MessageBoxButton.YesNo, MessageBoxImage.Question) == MessageBoxResult.Yes)
            {
                _studentRepository.Delete(SelectedStudent);
                await _context.SaveChangesAsync();
                Students.Remove(SelectedStudent);
                SelectedStudent = null;
                OnPropertyChanged(nameof(GroupAverage));
                OnPropertyChanged(nameof(LowPerformersCount));
            }
        }

        private async Task AddEnrollmentAsync()
        {
            if (SelectedStudent == null || Courses.Count == 0)
            {
                MessageBox.Show("Выберите студента и добавьте курсы!", "Внимание", MessageBoxButton.OK, MessageBoxImage.Warning);
                return;
            }

            var enrollment = new EnrollmentModel
            {
                StudentId = SelectedStudent.Id,
                CourseId = Courses[0].Id,
                EnrollmentDate = DateTime.Now,
                Status = "Активен",
                Student = SelectedStudent,
                Course = Courses[0]
            };

            await _enrollmentRepository.AddAsync(enrollment);
            await _context.SaveChangesAsync();

            Enrollments.Add(enrollment);
            SelectedStudent.Enrollments.Add(enrollment);
            MessageBox.Show("Студент зачислен!", "Успех", MessageBoxButton.OK, MessageBoxImage.Information);
        }

        private async Task AddGradeAsync()
        {
            if (SelectedStudent == null) return;

            SelectedStudent.Grades.Add(new GradeModel
            { Subject = "Новый предмет", Value = 5, Comment = "" });

            _studentRepository.Update(SelectedStudent);
            await _context.SaveChangesAsync();
            OnPropertyChanged(nameof(GroupAverage));
        }

        private async Task CreateTestDataAsync()
        {
            var math = new CourseModel { Name = "Математика" };
            var physics = new CourseModel { Name = "Физика" };
            await _courseRepository.AddAsync(math);
            await _courseRepository.AddAsync(physics);
            await _context.SaveChangesAsync();
            Courses.Add(math);
            Courses.Add(physics);

            var s1 = new StudentModel { FullName = "Иванов Иван" };
            s1.Grades.Add(new GradeModel { Subject = "Математика", Value = 5, Comment = "Отлично" });
            s1.Grades.Add(new GradeModel { Subject = "Физика", Value = 4, Comment = "Хорошо" });
            s1.Attendance.Add(new AttendanceRecord { Date = DateTime.Now.AddDays(-2), IsPresent = true });
            s1.Attendance.Add(new AttendanceRecord { Date = DateTime.Now.AddDays(-1), IsPresent = true });
            s1.Attendance.Add(new AttendanceRecord { Date = DateTime.Now, IsPresent = false });

            var s2 = new StudentModel { FullName = "Петров Петр" };
            s2.Grades.Add(new GradeModel { Subject = "Математика", Value = 4, Comment = "Хорошо" });
            s2.Grades.Add(new GradeModel { Subject = "Физика", Value = 5, Comment = "Отлично" });
            s2.Attendance.Add(new AttendanceRecord { Date = DateTime.Now.AddDays(-2), IsPresent = true });
            s2.Attendance.Add(new AttendanceRecord { Date = DateTime.Now.AddDays(-1), IsPresent = true });
            s2.Attendance.Add(new AttendanceRecord { Date = DateTime.Now, IsPresent = true });

            await _studentRepository.AddAsync(s1);
            await _studentRepository.AddAsync(s2);
            await _context.SaveChangesAsync();

            Students.Add(s1);
            Students.Add(s2);
            OnPropertyChanged(nameof(GroupAverage));
            OnPropertyChanged(nameof(LowPerformersCount));
        }

        public event PropertyChangedEventHandler PropertyChanged;
        protected void OnPropertyChanged([CallerMemberName] string name = null) =>
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
    }
}