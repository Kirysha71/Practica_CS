namespace Task1
{
    internal class Program
    {
        public delegate void VolumeControl(int volume);
        static void Main(string[] args)
        {
            var speaker =  new Speaker();
            var headphones = new Headphones();

            VolumeControl control = headphones.SetVolume;
            control += speaker.SetVolume;
            control(50);
        }
    }
}
