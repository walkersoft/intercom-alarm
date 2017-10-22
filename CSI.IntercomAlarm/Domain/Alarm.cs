using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CSI.IntercomAlarm.Domain
{
    [Serializable]
    public class Alarm
    {
        DateTime alarmTime;

        public string Title { get; set; }
        public string Time { get; set; }
        public bool IsActive { get; set; }

        public Alarm(string title, DateTime time, bool isActive = true)
        {
            Title = title;
            Time = time.ToShortTimeString();
            alarmTime = AdjustTimeToCurrentDay(time);
            IsActive = isActive;
        }

        DateTime AdjustTimeToCurrentDay(DateTime time)
        {
            DateTime newTime = DateTime.Today;

            newTime = newTime.AddHours(time.Hour);
            newTime = newTime.AddMinutes(time.Minute);

            return newTime;
        }

        public DateTime GetNativeAlarmTime()
        {
            return alarmTime;
        }
    }
}
