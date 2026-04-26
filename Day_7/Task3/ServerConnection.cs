using System;
using System.Collections.Generic;
using System.Text;

namespace Task3
{
    public class ServerConnection
    {
        public void Connect(int activeConnections)
        {
            if(activeConnections > 10)
            {
                throw new TooManyConnectionsException(activeConnections);
            }

            Console.WriteLine($"Подключение успешно. Активных подключений: {activeConnections}");
        }
    }
}
