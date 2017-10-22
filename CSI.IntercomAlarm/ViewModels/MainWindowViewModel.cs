using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using CSI.IntercomAlarm.Domain;
using System.Windows.Controls;

namespace CSI.IntercomAlarm.ViewModels
{
    public class MainWindowViewModel
    {
        AlarmPlayer alarmPlayer;
        AlarmFileManager alarmManager;
        AlarmScheduler alarmScheduler;
        MainWindow mainWindow;
        
        public MainWindowViewModel(MainWindow window)
        {
            alarmPlayer = new AlarmPlayer();
            alarmManager = new AlarmFileManager();
            alarmScheduler = new AlarmScheduler(alarmPlayer);
            mainWindow = window;
            ConfigureAlarmPlayer();
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
            ScheduleAlarms(alarmFile.Alarms);
            return alarmFile.Alarms;
        }

        public void SaveAlarmSet(string filename, ObservableCollection<Alarm> alarms)
        {
            AlarmFile alarmFile = new AlarmFile(alarms);
            alarmManager.SaveAlarmFile(filename, alarmFile);
            ScheduleAlarms(alarms);
        }

        public void PlayAlarm()
        {
            ConfigureAlarmPlayer();
            alarmPlayer.PlayAlarm();
        }

        public void PlayDefaultAlarm()
        {
            alarmPlayer.UsingDefaultSound = true;
            PlayAlarm();
        }

        public void ScheduleAlarms(ObservableCollection<Alarm> alarms)
        {
            alarmScheduler.ClearAllTimers();

            foreach(Alarm alarm in alarms)
            {
                if (alarm.IsActive)
                {
                    TimeSpan startingTime = alarm.GetNativeAlarmTime().TimeOfDay;
                    alarmScheduler.ScheduleAlarm(startingTime);
                }
            }
        }

        public void ConfigureAlarmPlayer()
        {
            alarmPlayer.UsingDefaultSound = mainWindow.IsUsingDefaultAlarm();
            alarmPlayer.AudioFile = mainWindow.GetCustomSoundFilename();
        }
    }
}
