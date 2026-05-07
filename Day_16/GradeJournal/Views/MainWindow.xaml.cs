using System.Windows;
using GradeJournal.Models;
using GradeJournal.ViewModels;

namespace GradeJournal
{
    public partial class MainWindow : Window
    {
        public MainWindow(UserModel user)
        {
            InitializeComponent();
            DataContext = new JournalViewModel(user);
            Title = $"Электронный журнал - {user.FullName}";
        }
    }
}