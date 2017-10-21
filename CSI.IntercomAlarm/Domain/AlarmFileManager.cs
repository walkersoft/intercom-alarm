using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.Serialization.Formatters.Binary;

namespace CSI.IntercomAlarm.Domain
{
    public class AlarmFileManager
    {
        BinaryFormatter formatter;

        public AlarmFileManager()
        {
            formatter = new BinaryFormatter();
        }

        public AlarmFile CreateNewAlarmFile(string filename)
        {
            AlarmFile alarmFile = new AlarmFile();

            using (Stream output = File.Create(filename))
            {
                formatter.Serialize(output, alarmFile);
            }

            return alarmFile;
        }

        public AlarmFile OpenAlarmFile(string filename)
        {
            AlarmFile alarmFile;

            using (Stream output = File.OpenRead(filename))
            {
                alarmFile = (AlarmFile)formatter.Deserialize(output);
            }

            return alarmFile;
        }

        public void SaveAlarmFile(string filename, AlarmFile alarmFile)
        {
            using (Stream input = File.OpenWrite(filename))
            {
                formatter.Serialize(input, alarmFile);
            }
        }
    }
}
