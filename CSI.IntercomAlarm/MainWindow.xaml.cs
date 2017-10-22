﻿using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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
using Microsoft.Win32;
using CSI.IntercomAlarm.Domain;
using CSI.IntercomAlarm.ViewModels;

namespace CSI.IntercomAlarm
{
    public partial class MainWindow : Window
    {
        MainWindowViewModel viewModel;
        SaveFileDialog saveDialog;
        OpenFileDialog openDialog;
        ObservableCollection<Alarm> currentAlarms;

        string currentAlarmFilename;

        public MainWindow()
        {
            InitializeComponent();

            DoStartupControlEnablementSetup();
            SetupSaveDialog();
            SetupOpenDialog();
            PopulateTimerSelections();
            CreateViewModel();
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

        void SetupSaveDialog()
        {
            saveDialog = new SaveFileDialog
            {
                Filter = "Alarm Data (.alm)|*.alm"
            };
        }

        void SetupOpenDialog()
        {
            openDialog = new OpenFileDialog
            {
                Filter = "Alarm Data (.alm)|*.alm"
            };
        }

        void CreateViewModel()
        {
            viewModel = new MainWindowViewModel(this);
        }

        void PopulateTimerSelections()
        {
            PopulateHourSelection();
            PopulateMinuteSelection();
        }

        void PopulateHourSelection()
        {
            for (int i = 1; i <= 12; i++)
            {
                alarmHourSelect.Items.Add(i.ToString());
            }

            alarmHourSelect.SelectedIndex = 0;
        }

        void PopulateMinuteSelection()
        {
            for (int i = 0; i < 60; i++)
            {
                string number = i.ToString();

                if (number.Length == 1)
                {
                    number = "0" + number;
                }

                alarmMinuteSelect.Items.Add(number);
            }

            alarmMinuteSelect.SelectedIndex = 0;
        }

        void DefaultAlarmCheckChanged(object sender, RoutedEventArgs e)
        {
            DisableAlarmSettingsControls();

            if ((bool)useDefaultSoundCheckbox.IsChecked == false)
            {
                EnableAlarmSettingControls();
            }
        }

        void UpdateCurrentAlarmsFilenameContent(string content)
        {
            currentAlarmFilename = content;
            currentAlarmFilenameLabel.Content = GetFilenameFromAbsolutePath(content);
        }

        string GetFilenameFromAbsolutePath(string absoluteName)
        {
            int lastDirectorySlashPosition = absoluteName.LastIndexOf(@"\");
            return absoluteName.Substring(lastDirectorySlashPosition + 1, absoluteName.Length - lastDirectorySlashPosition - 1);
        }

        void CreateNewAlarmsFile(object sender, RoutedEventArgs e)
        {            
            if (saveDialog.ShowDialog() == true)
            {
                currentAlarms = viewModel.GetNewAlarmSet(saveDialog.FileName);
                UpdateCurrentAlarmsFilenameContent(saveDialog.FileName);
            }

            EnableAlarmTimeSetupControls();
            EnableAlarmGridControls();
        }

        void OpenNewAlarmsFile(object sender, RoutedEventArgs e)
        {
            if (openDialog.ShowDialog() == true)
            {
                currentAlarms = viewModel.OpenAlarmSet(openDialog.FileName);
                UpdateCurrentAlarmsFilenameContent(openDialog.FileName);
            }

            EnableAlarmTimeSetupControls();
            EnableAlarmGridControls();
        }

        private void SaveAlarmsFile(object sender, RoutedEventArgs e)
        {
            viewModel.SaveAlarmSet(currentAlarmFilename, currentAlarms);
        }
    }
}
