﻿using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Net;
using System.Net.Mail;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;

namespace Code_Ninjas_Scheduler.MVVM.View
{
    /// <summary>
    /// Interaction logic for ScheduleView.xaml
    /// </summary>
    public partial class ScheduleView : UserControl
    {
        public SettingsView setView = new SettingsView();

        public ScheduleView()
        {
            InitializeComponent();
        }

        //Containers for dates etc.
        public List<int> selectedDates = new List<int>();
        public List<int> sortedDates = new List<int>();
        public string[] monthsList = { "January", "Febuary", "March", "April", "May", "June", "July", "August", "September", "October", "November", "December" };

        //Called when a button in the scheduler view is pressed
        private void AddDate(object sender, RoutedEventArgs e)
        {
            //If the button is toggled
            if ((bool)(sender as ToggleButton).IsChecked)
            {
                Debug.WriteLine("Checked");

                //Get the number inside the button
                var buttonContent = (sender as ToggleButton).Content;
                int buttonInt = Int32.Parse(buttonContent.ToString());
                //Add number to the list of selected dates
                selectedDates.Add(buttonInt);
            }
            //If the button is not toggled
            else
            {
                Debug.WriteLine("Unchecked");

                var buttonContent = (sender as ToggleButton).Content;
                int buttonInt = Int32.Parse(buttonContent.ToString());
                //Remove number from dates list
                selectedDates.Remove(buttonInt);
            }
        }

        //Called when the submit button in the scheduler view is pressed
        private void CreateList(object sender, RoutedEventArgs e)
        {
            //Assign the reference of the settings page to a variable for access
            var setView = new SettingsView();

            //String for final list of dates
            string messages = "";

            //Sort list of selected dates
            selectedDates.Sort();

            //Loops for every number in selectedDates
            foreach (var item in selectedDates)
            {
                //Creates a new DateTime of the date of the current value of "item"
                DateTime fullDate = new DateTime(DateTime.Now.Year, DateTime.Now.Month, item);

                //Parse day, month and date from fullDate
                string Day = fullDate.DayOfWeek.ToString();
                string Month = monthsList[fullDate.Month - 1];
                string Date = fullDate.Day.ToString();

                string datePostFix;

                //Set the postfix for the date
                if (Date == "1" || Date == "21" || Date == "31")
                {
                    datePostFix = "st";
                }
                else if (Date == "2" || Date == "22")
                {
                    datePostFix = "nd";
                }
                else if (Date == "3" || Date == "23")
                {
                    datePostFix = "rd";
                }
                else
                {
                    datePostFix = "th";
                }

                //Concatenates the final date of format "{Day} the {Date}{Postfix} of {Year}" to the messages string 
                messages += ($"\n\t{Day} the {Date}{datePostFix} of {Month}, {DateTime.Now.Year}");
            }

            try
            {
                //Initialize client for message transport
                var smtpClient = new SmtpClient("smtp.office365.com")
                {
                    Port = 587,
                    //Get credentials from settings
                    Credentials = new NetworkCredential($"{userSettings.Default.SenderEmail}", $"{userSettings.Default.SenderPassword}"),
                    EnableSsl = true,
                };

                //Format and send the message
                smtpClient.Send($"{userSettings.Default.SenderEmail}", $"{userSettings.Default.RecipientEmail}", "Schedule", $"{userSettings.Default.SenderName} Will Be Available On The Following Dates:\n{messages}\n\nThis Is An Email Auto Generated By The Code Ninjas Scheduler.");

                MessageBox.Show("Success :)", "Schedule Sent Successfully");

            }

            catch (Exception ex)
            {
                //Display error if one if thrown
                Debug.WriteLine(ex);
                MessageBox.Show("An Error Has Occured. Please Try Again Later.", "Error: Email Not Sent");
            }
        }

        //Called when cancel button in the schdule view is pressed
        private void Cancel(object sender, RoutedEventArgs e)
        {
            //Un-highlight all buttons
            UncheckButtons();
            //Clear list of selected dates
            selectedDates = new List<int>();
            return;
        }

        //Basically what is says on the tin
        private void UncheckButtons()
        {
            one.IsChecked = false;
            two.IsChecked = false;
            three.IsChecked = false;
            four.IsChecked = false;
            five.IsChecked = false;
            six.IsChecked = false;
            seven.IsChecked = false;
            eight.IsChecked = false;
            nine.IsChecked = false;
            ten.IsChecked = false;
            eleven.IsChecked = false;
            twelve.IsChecked = false;
            thirteen.IsChecked = false;
            fourteen.IsChecked = false;
            fifteen.IsChecked = false;
            sixteen.IsChecked = false;
            seventeen.IsChecked = false;
            eighteen.IsChecked = false;
            nineteen.IsChecked = false;
            twenty.IsChecked = false;
            twentyone.IsChecked = false;
            twentytwo.IsChecked = false;
            twentythree.IsChecked = false;
            twentyfour.IsChecked = false;
            twentyfive.IsChecked = false;
            twentysix.IsChecked = false;
            twentyseven.IsChecked = false;
            twentyeight.IsChecked = false;
            twentynine.IsChecked = false;
            thirty.IsChecked = false;
            thirtyone.IsChecked = false;
        }
    }
}
