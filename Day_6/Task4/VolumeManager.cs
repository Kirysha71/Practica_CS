using System;
using System.Collections.Generic;
using System.Text;

namespace Task4
{
    public class VolumeManager
    {
        private readonly Display _display;
        private readonly SpeakerSystem _speaker;

        public VolumeManager(VolumeControl control)
        {
            _display = new Display();
            _speaker = new SpeakerSystem();

            control.VolumeChanged += _display.OnVolumeChanged;
            control.VolumeChanged += _speaker.OnVolumeChanged;
        }
    }
}
