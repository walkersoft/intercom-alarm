using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Media;
using System.Text;

namespace CSI.IntercomAlarm.Domain
{
    public class AlarmPlayer
    {
        SoundPlayer player;

        public bool UsingDefaultSound { get; set; }
        public string AudioFile { get; set; }

        public AlarmPlayer()
        {
            player = new SoundPlayer();
        }

        public void PlayAlarm()
        {
            PlayAlarm(new object());
        }

        //Parameter is neccessary as this method is used as a TimerCallback
        public void PlayAlarm(Object stateInfo)
        {
            if (UsingDefaultSound)
            {
                PlayDefaultAlarm();
            }
            else
            {
                PlayCustomAlarm();
            }
        }

        void PlayDefaultAlarm()
        {
            player.Stream = CSI.IntercomAlarm.Properties.Resources.AlarmBellSound;
            player.Play();
        }

        void PlayCustomAlarm()
        {
            player.Stream = File.OpenRead(AudioFile);
            player.Play();
        }
    }
}
