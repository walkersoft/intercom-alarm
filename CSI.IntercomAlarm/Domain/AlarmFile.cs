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
        public ObservableCollection<Alarm> Alarms { get; private set; }

        public AlarmFile()
        {
            Alarms = new ObservableCollection<Alarm>();
        }

        public AlarmFile(ObservableCollection<Alarm> alarms)
        {
            Alarms = alarms;
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
