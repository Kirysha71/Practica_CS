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

        private void TxtPass_PasswordChanged(object sender, RoutedEventArgs e)
        {
            ViewModel.Password = TxtPass.Password;
        }

        private void BtnSwitch_Click(object sender, RoutedEventArgs e)
        {
            ViewModel.IsLoginMode = !ViewModel.IsLoginMode;
        }

        private void TxtLogin_TextChanged(object sender, TextChangedEventArgs e)
        {

        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {

        }
    }
}