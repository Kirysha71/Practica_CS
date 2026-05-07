using System.Windows;
using System.Windows.Controls;
using GradeJournal.ViewModels;

namespace GradeJournal
{
    public partial class LoginWindow : Window
    {
        public LoginViewModel ViewModel { get; } = new LoginViewModel();

        public LoginWindow()
        {
            InitializeComponent();
            DataContext = ViewModel;
        }

        private void BtnLogin_Click(object sender, RoutedEventArgs e)
        {
            ViewModel.Username = TxtLogin.Text;
            ViewModel.Password = TxtPass.Password;
            ViewModel.LoginCommand.Execute(null);
        }

        private void BtnRegister_Click(object sender, RoutedEventArgs e)
        {
            ViewModel.Username = TxtLogin.Text;
            ViewModel.Password = TxtPass.Password;
            ViewModel.RegisterCommand.Execute(null);
        }

        private void BtnSwitch_Click(object sender, RoutedEventArgs e)
        {
            ViewModel.IsLoginMode = !ViewModel.IsLoginMode;
        }
    }
}