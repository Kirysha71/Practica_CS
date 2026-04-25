namespace Task4
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var control = new VolumeControl();
            var manager = new VolumeManager(control);

            control.SetVolume(30);
            control.SetVolume(40);
            control.SetVolume(50);
        }
    }
}
