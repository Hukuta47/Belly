﻿using Belly.Enums;
using Belly.Objects;
using System;
using System.Windows;
using System.Windows.Controls;


namespace Belly.Dialogs
{
    public partial class IssueWindow : Window
    {
        public IssueType IssueType = IssueType.Music;
        public Issue Issue;

        public IssueWindow(string TextButton)
        {
            InitializeComponent();

            ListBox_AudioList.ItemsSource = Main.AudioList;
            Button_Accept.Content = TextButton;
            RadioButton_PlayMusic.IsChecked = true;
        }

        public IssueWindow(string TextButton, Issue Issue)
        {
            InitializeComponent();
            this.Issue = Issue;


            ListBox_AudioList.ItemsSource = Main.AudioList;
            Button_Accept.Content = TextButton;

            TextBox_NameIssue.Text = this.Issue.Name;
            TextBox_StartTime.Text = this.Issue.text_StartTime;
            TextBox_EndTime.Text = this.Issue.text_EndTime;
            CheckBox_EnabledIO.IsChecked = this.Issue.VolumeUpDown;

            if (Issue.MediaFile == null)
            {
                RadioButton_PlayMusic.IsChecked = true;
            }
            else
            {
                RadioButton_PlayAudio.IsChecked = true;
                CheckBox_EnabledIO.IsChecked = false;
                ListBox_AudioList.SelectedItem = (MediaFile)Issue.MediaFile;
            }
        }
        private void Create_Click(object sender, RoutedEventArgs e)
        {
            string StartTime_text = TextBox_StartTime.Text;
            string EndTime_text = TextBox_EndTime.Text;

            int StartTime_hours = int.Parse(StartTime_text.Split(":")[0]);
            int StartTime_minutes = int.Parse(StartTime_text.Split(":")[1]);
            int EndTime_hours;
            int EndTime_minutes;


            string Name = TextBox_NameIssue.Text;
            TimeOnly StartTime = new TimeOnly(StartTime_hours, StartTime_minutes);
            TimeOnly EndTime;

            MediaFile mediaFile = ListBox_AudioList.SelectedItem as MediaFile;
            

            switch (IssueType)
            {
                case IssueType.Music:

                    
                    
                    EndTime_hours = int.Parse(EndTime_text.Split(":")[0]);
                    EndTime_minutes = int.Parse(EndTime_text.Split(":")[1]);
                    EndTime = new TimeOnly(EndTime_hours, EndTime_minutes);

                    Issue = new Issue(Name, StartTime, EndTime, (bool)CheckBox_EnabledIO.IsChecked);
                    break;
                case IssueType.Audio:



                    Issue = new Issue(Name, StartTime, mediaFile);
                    break;
            }

            DialogResult = true;
        }
        private void Cancel_Click(object sender, RoutedEventArgs e)
        {
            DialogResult = false;
        }

        private void RadioButton_Checked(object sender, RoutedEventArgs e)
        {
            var RadioButton = (RadioButton)sender;

            switch (RadioButton.Tag)
            {
                case "MusicFile":
                    IssueType = IssueType.Music;
                    TextBox_EndTime.IsEnabled = true;
                    CheckBox_EnabledIO.IsEnabled = true;
                    GroupBox_File.IsEnabled = false;

                    break;
                case "AudioFile":

                    IssueType = IssueType.Audio;
                    TextBox_EndTime.IsEnabled = false;
                    CheckBox_EnabledIO.IsEnabled = false;
                    CheckBox_EnabledIO.IsChecked = false;
                    GroupBox_File.IsEnabled = true;

                    TextBox_EndTime.Text = "null";
                break;
            }
        }
    }
}
