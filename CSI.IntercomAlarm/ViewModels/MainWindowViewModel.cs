using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using CSI.IntercomAlarm.Domain;

namespace CSI.IntercomAlarm.ViewModels
{
    public class MainWindowViewModel
    {
        AlarmPlayer alarmPlayer;
        AlarmFileManager alarmManager;
        MainWindow mainWindow;
        
        public MainWindowViewModel(MainWindow window)
        {
            alarmPlayer = new AlarmPlayer();
            alarmManager = new AlarmFileManager();
            mainWindow = window;
        }

        public ObservableCollection<Alarm> GetNewAlarmSet(string filename)
        {
            AlarmFile alarmFile;

            alarmFile = alarmManager.CreateNewAlarmFile(filename);
            return alarmFile.Alarms;
        }

        public ObservableCollection<Alarm> OpenAlarmSet(string filename)
        {
            AlarmFile alarmFile;

            alarmFile = alarmManager.OpenAlarmFile(filename);
            return alarmFile.Alarms;
        }

        public void SaveAlarmSet(string filename, ObservableCollection<Alarm> alarms)
        {
            AlarmFile alarmFile = new AlarmFile(alarms);
            alarmManager.SaveAlarmFile(filename, alarmFile);
        }

        public void PlayDefaultAlarm()
        {
            alarmPlayer.PlayDefaultAlarm();
        }
    }
}
