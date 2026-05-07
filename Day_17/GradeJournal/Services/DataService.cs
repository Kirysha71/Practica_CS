using System;
using System.Collections.ObjectModel;
using System.IO;
using System.Text.Json;
using System.Threading.Tasks;
using GradeJournal.Models;

namespace GradeJournal.Services
{
    public static class DataService
    {
        private static string BasePath = AppDomain.CurrentDomain.BaseDirectory;
        public static string UsersFile => Path.Combine(BasePath, "users.json");
        public static string DataFile => Path.Combine(BasePath, "journal.json");

        public static async Task<ObservableCollection<UserModel>> LoadUsersAsync()
        {
            if (!File.Exists(UsersFile))
            {
                var defaultUsers = new ObservableCollection<UserModel>
                {
                    new UserModel { Username = "teacher", Password = "123", FullName = "Иванов И.И. (Преподаватель)" },
                    new UserModel { Username = "student", Password = "123", FullName = "Петров П.П. (Студент)" }
                };
                await SaveUsersAsync(defaultUsers);
                return defaultUsers;
            }

            for (int i = 0; i < 5; i++)
            {
                try
                {
                    using (var stream = new FileStream(UsersFile, FileMode.Open, FileAccess.Read, FileShare.ReadWrite))
                    using (var reader = new StreamReader(stream))
                    {
                        string json = await reader.ReadToEndAsync();
                        return JsonSerializer.Deserialize<ObservableCollection<UserModel>>(json);
                    }
                }
                catch (IOException) when (i < 4)
                {
                    await Task.Delay(100);
                }
            }

            return new ObservableCollection<UserModel>();
        }

        public static async Task SaveUsersAsync(ObservableCollection<UserModel> users)
        {
            string json = JsonSerializer.Serialize(users, new JsonSerializerOptions { WriteIndented = true });

            for (int i = 0; i < 5; i++)
            {
                try
                {
                    using (var stream = new FileStream(UsersFile, FileMode.Create, FileAccess.Write, FileShare.None))
                    using (var writer = new StreamWriter(stream))
                    {
                        await writer.WriteAsync(json);
                    }
                    return;
                }
                catch (IOException) when (i < 4)
                {
                    await Task.Delay(100);
                }
            }
        }

        public static async Task<UserModel> LoginAsync(string username, string password)
        {
            if (string.IsNullOrWhiteSpace(username) || string.IsNullOrWhiteSpace(password))
                return null;

            var users = await LoadUsersAsync();
            foreach (var u in users)
            {
                if (u.Username == username && u.Password == password)
                    return u;
            }
            return null;
        }

        public static async Task<bool> RegisterAsync(UserModel newUser)
        {
            if (string.IsNullOrWhiteSpace(newUser.Username) || string.IsNullOrWhiteSpace(newUser.Password))
                return false;

            if (newUser.Username.Length < 3)
                return false;

            var users = await LoadUsersAsync();
            foreach (var u in users)
            {
                if (u.Username == newUser.Username)
                    return false;
            }
            users.Add(newUser);
            await SaveUsersAsync(users);
            return true;
        }

        public static async Task SaveJournalAsync(ObservableCollection<StudentModel> students)
        {
            string json = JsonSerializer.Serialize(students, new JsonSerializerOptions { WriteIndented = true });

            for (int i = 0; i < 5; i++)
            {
                try
                {
                    using (var stream = new FileStream(DataFile, FileMode.Create, FileAccess.Write, FileShare.None))
                    using (var writer = new StreamWriter(stream))
                    {
                        await writer.WriteAsync(json);
                    }
                    return;
                }
                catch (IOException) when (i < 4)
                {
                    await Task.Delay(100);
                }
            }
        }

        public static async Task<ObservableCollection<StudentModel>> LoadJournalAsync()
        {
            if (!File.Exists(DataFile))
            {
                return CreateTestData();
            }

            for (int i = 0; i < 5; i++)
            {
                try
                {
                    using (var stream = new FileStream(DataFile, FileMode.Open, FileAccess.Read, FileShare.ReadWrite))
                    using (var reader = new StreamReader(stream))
                    {
                        string json = await reader.ReadToEndAsync();
                        return JsonSerializer.Deserialize<ObservableCollection<StudentModel>>(json);
                    }
                }
                catch (IOException) when (i < 4)
                {
                    await Task.Delay(100);
                }
            }

            return CreateTestData();
        }

        private static ObservableCollection<StudentModel> CreateTestData()
        {
            var students = new ObservableCollection<StudentModel>();

            var s1 = new StudentModel { FullName = "Иванов Иван Иванович" };
            s1.Grades.Add(new GradeModel { Subject = "Математика", Value = 5, Comment = "Отлично" });
            s1.Grades.Add(new GradeModel { Subject = "Физика", Value = 4, Comment = "Хорошо" });
            s1.Grades.Add(new GradeModel { Subject = "Программирование", Value = 5, Comment = "Отлично" });

            s1.Attendance.Add(new AttendanceRecord { Date = new DateTime(2026, 5, 3), IsPresent = true });
            s1.Attendance.Add(new AttendanceRecord { Date = new DateTime(2026, 5, 4), IsPresent = true });
            s1.Attendance.Add(new AttendanceRecord { Date = new DateTime(2026, 5, 5), IsPresent = false });
            s1.Attendance.Add(new AttendanceRecord { Date = new DateTime(2026, 5, 6), IsPresent = true });

            var s2 = new StudentModel { FullName = "Петров Петр Петрович" };
            s2.Grades.Add(new GradeModel { Subject = "Математика", Value = 4, Comment = "Хорошо" });
            s2.Grades.Add(new GradeModel { Subject = "Физика", Value = 5, Comment = "Отлично" });
            s2.Grades.Add(new GradeModel { Subject = "Программирование", Value = 4, Comment = "Хорошо" });

            s2.Attendance.Add(new AttendanceRecord { Date = new DateTime(2026, 5, 3), IsPresent = true });
            s2.Attendance.Add(new AttendanceRecord { Date = new DateTime(2026, 5, 4), IsPresent = true });
            s2.Attendance.Add(new AttendanceRecord { Date = new DateTime(2026, 5, 5), IsPresent = true });
            s2.Attendance.Add(new AttendanceRecord { Date = new DateTime(2026, 5, 6), IsPresent = true });

            var s3 = new StudentModel { FullName = "Немец Артем Сергеевич" };
            s3.Grades.Add(new GradeModel { Subject = "Немецкий", Value = 5, Comment = "Отлично" });
            s3.Grades.Add(new GradeModel { Subject = "Английский", Value = 2, Comment = "Надо подтянуть" });
            s3.Grades.Add(new GradeModel { Subject = "Программирование", Value = 5, Comment = "Отлично" });

            s3.Attendance.Add(new AttendanceRecord { Date = new DateTime(2026, 5, 3), IsPresent = true });
            s3.Attendance.Add(new AttendanceRecord { Date = new DateTime(2026, 5, 4), IsPresent = true });
            s3.Attendance.Add(new AttendanceRecord { Date = new DateTime(2026, 5, 5), IsPresent = true });
            s3.Attendance.Add(new AttendanceRecord { Date = new DateTime(2026, 5, 6), IsPresent = true });

            students.Add(s1);
            students.Add(s2);
            students.Add(s3);

            return students;
        }
    }
}