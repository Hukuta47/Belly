using Belly.Objects;
using System;
using System.Windows;
using System.Windows.Controls;


namespace Belly.Dialogs
{
    public partial class IssueWindow : Window
    {
        public Issue Issue;

        public IssueWindow(string TextButton)
        {
            InitializeComponent();
            Button_Accept.Content = TextButton;
        }
        public IssueWindow(string TextButton, Issue Issue)
        {
            InitializeComponent();
            Button_Accept.Content = TextButton;

            this.Issue = Issue;
        }


        private void Create_Click(object sender, RoutedEventArgs e)
        {
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
                    TextBox_EndTime.IsEnabled = true;
                    GroupBox_File.IsEnabled = false;
                break;
                case "AudioFile":
                    TextBox_EndTime.IsEnabled = false;
                    GroupBox_File.IsEnabled = true;
                break;
            }
        }
    }
}
