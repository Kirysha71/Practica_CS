using System.Windows;
using System.Windows.Input;
using GradeJournal.Models;
using GradeJournal.Services;

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
            set
            {
                _isLoginMode = value;
            }
        }

        public ICommand LoginCommand { get; }
        public ICommand RegisterCommand { get; }
        public ICommand SwitchModeCommand { get; }

        public LoginViewModel()
        {
            LoginCommand = new RelayCommand(_ => LoginAsync());
            RegisterCommand = new RelayCommand(_ => RegisterAsync());
            SwitchModeCommand = new RelayCommand(_ => IsLoginMode = !IsLoginMode);
        }

        private async void LoginAsync()
        {
            var user = await DataService.LoginAsync(Username, Password);
            if (user != null)
            {
                new MainWindow(user).Show();
                Application.Current.Windows[0].Close();
            }
            else
            {
                MessageBox.Show("Неверный логин или пароль");
            }
        }

        private async void RegisterAsync()
        {
            bool success = await DataService.RegisterAsync(new Models.UserModel
            {
                Username = Username,
                Password = Password
            });
            if (success)
            {
                MessageBox.Show("Регистрация успешна! Теперь войдите.");
                IsLoginMode = true;
            }
            else
            {
                MessageBox.Show("Пользователь уже существует");
            }
        }
    }
}