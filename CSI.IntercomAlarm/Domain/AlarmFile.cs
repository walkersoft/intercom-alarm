using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;

namespace CSI.IntercomAlarm.Domain
{
    [Serializable]
    public class AlarmFile
    {
        public ObservableCollection<Alarm> Alarms
        {
            get
            {
                return Alarms;
            }

            private set
            {
                Alarms = value;
            }
        }

        public AlarmFile()
        {
            Alarms = new ObservableCollection<Alarm>();
        }

        public void AddAlarm(Alarm alarm)
        {
            Alarms.Add(alarm);
        }

        public void RemoveAlarm(Alarm alarm)
        {
            Alarms.Remove(alarm);
        }
    }
}
