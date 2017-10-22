using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;

namespace CSI.IntercomAlarm.Domain
{
    public class AlarmScheduler
    {
        TimeSpan alarmInterval;
        List<Timer> timers;
        AlarmPlayer alarmPlayer;

        public AlarmScheduler(AlarmPlayer player)
        {
            alarmPlayer = player;
            alarmInterval = TimeSpan.FromDays(1);
            timers = new List<Timer>();
        }

        public void ScheduleAlarm(TimeSpan time)
        {            
            Timer timer = new Timer(alarmPlayer.PlayAlarm, null, CalculateAlarmStartTime(time), alarmInterval);
            timers.Add(timer);
        }

        public void ClearAllTimers()
        {
            foreach(Timer timer in timers)
            {
                timer.Dispose();
            }
        }

        TimeSpan CalculateAlarmStartTime(TimeSpan intendedStart)
        {
            DateTime currentTime = DateTime.Now;
            TimeSpan calculatedStart = TimeSpan.Zero;

            if (currentTime.TimeOfDay < intendedStart)
            {
                calculatedStart = intendedStart - currentTime.TimeOfDay;
            }
            else
            {
                calculatedStart = TimeSpan.FromDays(1) + intendedStart - currentTime.TimeOfDay;
            }

            System.Diagnostics.Debug.Print(calculatedStart.ToString());

            return calculatedStart;
        }
    }
}
