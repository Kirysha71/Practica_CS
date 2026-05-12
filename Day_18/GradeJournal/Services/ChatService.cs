using System;
using System.IO;
using System.IO.Pipes;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace GradeJournal.Services
{
    public class ChatService : IDisposable
    {
        private NamedPipeServerStream _server;
        private NamedPipeClientStream _client;
        private bool _isServer;
        private bool _disposed;
        private bool _isConnected;

        public event EventHandler<string> MessageReceived;
        public event EventHandler Connected;
        public event EventHandler Disconnected;

        public async Task StartServerAsync()
        {
            try
            {
                _server = new NamedPipeServerStream("GradeJournalChatPipe", PipeDirection.InOut, 1, PipeTransmissionMode.Message, PipeOptions.Asynchronous);
                await _server.WaitForConnectionAsync();
                _isServer = true;
                _isConnected = true;
                Connected?.Invoke(this, EventArgs.Empty);
                _ = ReadMessagesAsync();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ошибка запуска сервера чата: {ex.Message}");
            }
        }

        public async Task ConnectToServerAsync()
        {
            int attempts = 0;
            int maxAttempts = 5;

            while (attempts < maxAttempts && !_disposed)
            {
                try
                {
                    _client = new NamedPipeClientStream(".", "GradeJournalChatPipe", PipeDirection.InOut, PipeOptions.Asynchronous);
                    await _client.ConnectAsync(2000);
                    _isServer = false;
                    _isConnected = true;
                    Connected?.Invoke(this, EventArgs.Empty);
                    _ = ReadMessagesAsync();
                    return;
                }
                catch
                {
                    attempts++;
                    if (attempts >= maxAttempts)
                    {
                        MessageBox.Show("Не удалось подключиться к чату.Убедитесь, что учитель запустил приложение.", "Ошибка подключения", MessageBoxButton.OK, MessageBoxImage.Warning);
                        return;
                    }
                    await Task.Delay(1000);
                }
            }
        }

        public async Task SendMessageAsync(string message)
        {
            if (!_isConnected)
            {
                MessageBox.Show("Нет подключения к чату!");
                return;
            }

            try
            {
                byte[] data = Encoding.UTF8.GetBytes(message);
                if (_isServer && _server.IsConnected)
                {
                    await _server.WriteAsync(data, 0, data.Length);
                    await _server.FlushAsync();
                }
                else if (!_isServer && _client.IsConnected)
                {
                    await _client.WriteAsync(data, 0, data.Length);
                    await _client.FlushAsync();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ошибка отправки: {ex.Message}");
                _isConnected = false;
                Disconnected?.Invoke(this, EventArgs.Empty);
            }
        }

        private async Task ReadMessagesAsync()
        {
            byte[] buffer = new byte[1024];
            while (!_disposed && _isConnected)
            {
                try
                {
                    int bytesRead = 0;
                    if (_isServer && _server.IsConnected)
                        bytesRead = await _server.ReadAsync(buffer, 0, buffer.Length);
                    else if (!_isServer && _client.IsConnected)
                        bytesRead = await _client.ReadAsync(buffer, 0, buffer.Length);

                    if (bytesRead > 0)
                    {
                        string message = Encoding.UTF8.GetString(buffer, 0, bytesRead);
                        MessageReceived?.Invoke(this, message);
                    }
                }
                catch (IOException)
                {
                    _isConnected = false;
                    Disconnected?.Invoke(this, EventArgs.Empty);
                    break;
                }
                catch (ObjectDisposedException)
                {
                    break;
                }
                await Task.Delay(100);
            }
        }

        public bool IsConnected => _isConnected;

        public void Dispose()
        {
            _disposed = true;
            _server?.Dispose();
            _client?.Dispose();
        }
    }
}