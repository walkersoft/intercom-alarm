using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace CSI.IntercomAlarm
{
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            DoStartupControlEnablementSetup();
        }

        void DoStartupControlEnablementSetup()
        {
            DisableAlarmTimeSetupControls();
            DisableAlarmGridControls();
            DisableAlarmSettingsControls();
        }

        void DisableAlarmTimeSetupControls()
        {
            alarmTitleTextbox.IsEnabled = false;
            alarmHourSelect.IsEnabled = false;
            alarmMinuteSelect.IsEnabled = false;
            alarmAmPmSelect.IsEnabled = false;
            applyAlarmButton.IsEnabled = false;
        }

        void EnableAlarmTimeSetupControls()
        {
            alarmTitleTextbox.IsEnabled = true;
            alarmHourSelect.IsEnabled = true;
            alarmMinuteSelect.IsEnabled = true;
            alarmAmPmSelect.IsEnabled = true;
            applyAlarmButton.IsEnabled = true;
        }

        void DisableAlarmGridControls()
        {
            currentAlarmsGrid.IsEnabled = false;
            removeAlarmButton.IsEnabled = false;
            saveAlarmsButton.IsEnabled = false;
        }

        void EnableAlarmGridControls()
        {
            currentAlarmsGrid.IsEnabled = true;
            removeAlarmButton.IsEnabled = true;
            saveAlarmsButton.IsEnabled = true;
        }

        void DisableAlarmSettingsControls()
        {
            alarmSoundFilenameTextbox.IsEnabled = false;
            browseForSoundButton.IsEnabled = false;
        }

        void EnableAlarmSettingControls()
        {
            alarmSoundFilenameTextbox.IsEnabled = true;
            browseForSoundButton.IsEnabled = true;
        }

        void DefaultAlarmCheckChanged(object sender, RoutedEventArgs e)
        {
            DisableAlarmSettingsControls();

            if ((bool)useDefaultSoundCheckbox.IsChecked == false)
            {
                EnableAlarmSettingControls();
            }
        }
    }
}
