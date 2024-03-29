﻿using Code_Ninjas_Scheduler;
using System.Windows;
using System.Windows.Controls;

namespace CodeNinjasScheduler.MVVM.View
{
    /// <summary>
    /// Interaction logic for SettingsView.xaml
    /// </summary>
    public partial class SettingsView : UserControl
    {
        public SettingsView()
        {
            InitializeComponent();
            //Make sure runtime settings are up to date
            userSettings.Default.Upgrade();
            UpdateTextbox();
        }

        //Set text in settings textboxes to stored settings
        public void UpdateTextbox()
        {
            emailField.Text = userSettings.Default.SenderEmail.ToString();
            passwordField.Text = userSettings.Default.SenderPassword.ToString();
            nameField.Text = userSettings.Default.SenderName.ToString();
            recipientEmailField.Text = userSettings.Default.RecipientEmail.ToString();
        }

        //Called when submit button in the settings view is pressed
        //Saves new settings based on text in textboxes
        public void ApplySettings(object sender, RoutedEventArgs e)
        {
            userSettings.Default.SenderEmail = emailField.Text;
            userSettings.Default.SenderName = nameField.Text;
            userSettings.Default.SenderPassword = passwordField.Text;
            userSettings.Default.RecipientEmail = recipientEmailField.Text;
            userSettings.Default.Save();
            userSettings.Default.Reload();
            userSettings.Default.Upgrade();
            UpdateTextbox();
        }

        //Called when cancel button in the settings view is pressed
        //Resets all settings
        public void ClearSettings(object sender, RoutedEventArgs e)
        {
            userSettings.Default.Reset();
            UpdateTextbox();
        }
    }
}
