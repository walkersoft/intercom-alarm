using System;
using System.Collections.Generic;
using System.Linq;
using System.Media;
using System.Text;

namespace CSI.IntercomAlarm.Domain
{
    public class AlarmPlayer
    {
        SoundPlayer player;

        public AlarmPlayer()
        {
            player = new SoundPlayer();
        }

        public void PlayDefaultAlarm()
        {
            player.Stream = CSI.IntercomAlarm.Properties.Resources.AlarmBellSound;
            player.Play();
        }
    }
}
