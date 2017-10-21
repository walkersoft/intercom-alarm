using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CSI.IntercomAlarm.Domain
{
    [Serializable]
    public class Alarm
    {
        public string Title { get; private set; }
        public DateTime Time { get; private set; }
        public bool IsActive { get; private set; }

        public Alarm(string title, DateTime time, bool isActive = true)
        {
            Title = title;
            Time = time;
            IsActive = isActive;
        }
    }
}
