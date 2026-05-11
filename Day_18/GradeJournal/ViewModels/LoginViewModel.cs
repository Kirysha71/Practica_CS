using System.Linq;
using System.Windows;
using System.Windows.Input;
using GradeJournal.Data;
using GradeJournal.Models;
using Microsoft.EntityFrameworkCore;

namespace GradeJournal.ViewModels
{
    public class LoginViewModel
    {
        private string _username;
        private string _password;
        private bool _isLoginMode = true;

        public string Username
        {
            get => _username;
            set { _username = value; }
        }

        public string Password
        {
            get => _password;
            set { _password = value; }
        }

        public bool IsLoginMode
        {
            get => _isLoginMode;
            set { _isLoginMode = value; }
        }

        public ICommand LoginCommand { get; }
        public ICommand RegisterCommand { get; }
        public ICommand ToggleModeCommand { get; }

        public LoginViewModel()
        {
            LoginCommand = new RelayCommand(_ => LoginAsync());
            RegisterCommand = new RelayCommand(_ => RegisterAsync());
            ToggleModeCommand = new RelayCommand(_ => IsLoginMode = !IsLoginMode);
        }

        private async void LoginAsync()
        {
            if (string.IsNullOrWhiteSpace(Username) || string.IsNullOrWhiteSpace(Password))
            {
                MessageBox.Show("Введите логин и пароль!");
                return;
            }

            using (var context = new ApplicationDbContext())
            {
                await context.Database.EnsureCreatedAsync();

                var user = await context.Users.FirstOrDefaultAsync(u => u.Username == Username && u.Password == Password);

                if (user != null)
                {
                    new MainWindow(user).Show();
                    Application.Current.Windows[0].Close();
                }
                else
                {
                    MessageBox.Show("Неверный логин или пароль!");
                }
            }
        }

        private async void RegisterAsync()
        {
            if (string.IsNullOrWhiteSpace(Username) || string.IsNullOrWhiteSpace(Password))
            {
                MessageBox.Show("Введите логин и пароль!");
                return;
            }

            if (Username.Length < 3)
            {
                MessageBox.Show("Логин должен быть не менее 3 символов!");
                return;
            }

            using (var context = new ApplicationDbContext())
            {
                await context.Database.EnsureCreatedAsync();

                var existing = await context.Users.FirstOrDefaultAsync(u => u.Username == Username);
                if (existing != null)
                {
                    MessageBox.Show("Пользователь уже существует!");
                    return;
                }

                var newUser = new UserModel { Username = Username, Password = Password, FullName = Username };
                await context.Users.AddAsync(newUser);
                await context.SaveChangesAsync();
            }

            MessageBox.Show("Регистрация успешна! Теперь войдите.");
            IsLoginMode = true;
        }
    }
}