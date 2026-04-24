using System;
using System.Collections.Generic;
using System.Text;

namespace Task4
{
    public class NetworkAdapter : IWiFiConnection, IEthernetConnection
    {
        void IWiFiConnection.Connect()
        {
            Console.WriteLine("WiFi подключен");
        }

        void IEthernetConnection.Connect()
        {
            Console.WriteLine("Ethernet подключен");
        }
    }
}
