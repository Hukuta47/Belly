using Belly.Classes.StaticClasses;
using Belly.Objects;
using System;
using System.Collections.Generic;
using System.Windows;


namespace Belly.Dialogs
{
    public partial class AddIssueWindow : Window
    {
        public string NameIssue;
        public TimeOnly StartTime;
        public TimeOnly? EndTime;
        public MediaFile MediaData;



        public AddIssueWindow(string TextButton)
        {
            InitializeComponent();
            Button_Accept.Content = TextButton;
        }

        private void Create_Click(object sender, RoutedEventArgs e)
        {
            DialogResult = true;
        }

        private void Cancel_Click(object sender, RoutedEventArgs e)
        {
            DialogResult = false;
        }

    }
}
