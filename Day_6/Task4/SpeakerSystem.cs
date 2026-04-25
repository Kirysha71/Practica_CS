using System;
using System.Collections.Generic;
using System.Text;

namespace Task4
{
    public class SpeakerSystem
    {
        public void OnVolumeChanged(object sender, int volume)
        {
            Console.WriteLine($"Изменение громкости на {volume}%");
        }
    }
}
