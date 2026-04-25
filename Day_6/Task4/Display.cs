using System;
using System.Collections.Generic;
using System.Text;

namespace Task4
{
    public class Display
    {
        public void OnVolumeChanged(object sender, int volume)
        {
            Console.WriteLine($"Громкость {volume}%");
        }
    }
}
