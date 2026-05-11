using System;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Threading.Tasks;
using System.Windows.Input;
using System.Windows.Media;
using GradeJournal.Models;
using GradeJournal.Services;

namespace GradeJournal.ViewModels
{
    public class ChatViewModel : INotifyPropertyChanged
    {
        private readonly ChatService _chatService;
        private readonly string _currentUserName;
        private string _messageText;
        private bool _isConnected;

        public ObservableCollection<ChatMessage> Messages { get; } = new ObservableCollection<ChatMessage>();

        public string MessageText
        {
            get => _messageText;
            set { _messageText = value; OnPropertyChanged(); }
        }

        public bool IsConnected
        {
            get => _isConnected;
            set
            {
                _isConnected = value;
                OnPropertyChanged();
                OnPropertyChanged(nameof(ConnectionStatusText));
                OnPropertyChanged(nameof(ConnectionColor));
            }
        }

        public string ConnectionStatusText => IsConnected ? "Подключено" : "Отключено";
        public SolidColorBrush ConnectionColor => IsConnected ? Brushes.Green : Brushes.Red;

        public ICommand SendMessageCommand { get; }

        public ChatViewModel(string currentUserName, bool isTeacher)
        {
            _currentUserName = currentUserName;
            _chatService = new ChatService();

            SendMessageCommand = new RelayCommand(_ => SendMessage(), _ => !string.IsNullOrWhiteSpace(MessageText));

            _chatService.MessageReceived += OnMessageReceived;
            _chatService.Connected += OnConnected;
            _chatService.Disconnected += OnDisconnected;

            if (isTeacher)
            {
                _ = _chatService.StartServerAsync();
            }
            else
            {
                _ = _chatService.ConnectToServerAsync();
            }
        }

        private void OnMessageReceived(object sender, string message)
        {
            System.Windows.Application.Current.Dispatcher.Invoke(() =>
            {
                Messages.Add(new ChatMessage
                {
                    Sender = "Собеседник",
                    Text = message,
                    Time = DateTime.Now,
                    IsFromCurrentUser = false
                });
            });
        }

        private void OnConnected(object sender, EventArgs e)
        {
            System.Windows.Application.Current.Dispatcher.Invoke(() =>
            {
                IsConnected = true;
                Messages.Add(new ChatMessage
                {
                    Sender = "Система",
                    Text = "Подключено к чату",
                    Time = DateTime.Now,
                    IsFromCurrentUser = true
                });
            });
        }

        private void OnDisconnected(object sender, EventArgs e)
        {
            System.Windows.Application.Current.Dispatcher.Invoke(() =>
            {
                IsConnected = false;
                Messages.Add(new ChatMessage
                {
                    Sender = "Система",
                    Text = "Отключено от чата",
                    Time = DateTime.Now,
                    IsFromCurrentUser = true
                });
            });
        }

        private async void SendMessage()
        {
            if (string.IsNullOrWhiteSpace(MessageText))
                return;

            var message = new ChatMessage
            {
                Sender = _currentUserName,
                Text = MessageText,
                Time = DateTime.Now,
                IsFromCurrentUser = true
            };

            Messages.Add(message);
            await _chatService.SendMessageAsync(MessageText);
            MessageText = string.Empty;
        }

        public event PropertyChangedEventHandler PropertyChanged;
        protected void OnPropertyChanged([CallerMemberName] string name = null) =>
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
    }
}