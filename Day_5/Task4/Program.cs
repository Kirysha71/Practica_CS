namespace Task4
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var adapter = new NetworkAdapter();

            IWiFiConnection wifi = adapter;
            wifi.Connect();

            IEthernetConnection ethernet = adapter;
            ethernet.Connect();
        }
    }
}
