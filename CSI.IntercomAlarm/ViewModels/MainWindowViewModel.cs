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
        AlarmFileManager alarmManager;
        MainWindow mainWindow;
        
        public MainWindowViewModel(MainWindow window)
        {
            alarmManager = new AlarmFileManager();
            mainWindow = window;
        }

        public ObservableCollection<Alarm> GetNewAlarmSet(string filename)
        {
            AlarmFile alarmFile;

            alarmManager.CreateNewAlarmFile(filename);
            alarmFile = alarmManager.OpenAlarmFile(filename);

            return alarmFile.Alarms;
        }
    }
}
