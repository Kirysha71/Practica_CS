using System.Windows;
using System.Windows.Input;
using GradeJournal.ViewModels;

namespace GradeJournal
{
    public partial class ChatWindow : Window
    {
        public ChatWindow(string currentUserName, bool isTeacher)
        {
            InitializeComponent();
            DataContext = new ChatViewModel(currentUserName, isTeacher);
            Owner = Application.Current.MainWindow;
        }

        private void TextBox_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Enter && Keyboard.Modifiers != ModifierKeys.Shift)
            {
                e.Handled = true;
                if (DataContext is ChatViewModel vm && vm.SendMessageCommand.CanExecute(null))
                {
                    vm.SendMessageCommand.Execute(null);
                }
            }
        }
    }
}