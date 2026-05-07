using System;
using System.Collections.Generic;
using System.IO.Pipes;
using System.Text;

namespace GradeJournal.Services
{
    public class ChatService
    {
        private NamedPipeServerStream _server;
        private NamedPipeClientStream _client;
        private bool _isServer = true;

        public async Task StartServerAsync()
        {
            try
            {
                _server = new NamedPipeServerStream("GradeJournal_Chat", PipeDirection.InOut);
                await _server.WaitForConnectionAsync();
            }
            catch (Exception ex)
            {
                _isServer = false;
                await ConnectAsync();
            }
        }

        public async Task ConnectAsync()
        {
            _client = new NamedPipeClientStream(".", "GradeJournal_Chat", PipeDirection.InOut);
            await _client.ConnectAsync();
        }

        public async Task SendMessageAsync(string message)
        {
            try
            {
                PipeStream stream = _isServer ? (PipeStream)_server : _client;
                if (stream != null && stream.IsConnected)
                {
                    byte[] data = Encoding.UTF8.GetBytes(message);
                    await stream.WriteAsync(data, 0, data.Length);
                    stream.Flush();
                }
            }
            catch { }
        }
    }
}
