using System;
using System.Collections.Generic;
using System.Text;

namespace Task4
{
    public class VolumeControl
    {
        public event EventHandler<int> VolumeChanged;
        private int _volume;

        public void SetVolume(int volume)
        {
            if (volume < 0) volume = 0;
            if (volume > 100) volume = 100;

            _volume = volume;
            VolumeChanged?.Invoke(this, volume);
        }
    }
}
