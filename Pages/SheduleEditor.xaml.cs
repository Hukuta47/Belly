using Newtonsoft.Json;
using System.IO;
using Belly.Objects;
using System.Windows.Controls;
using System.Collections.Generic;
using System.Windows;
using Belly.Dialogs;
using Belly.Classes.StaticClasses;
using NAudio.Mixer;

namespace Belly.Pages
{

    public partial class SheduleEditor : Page
    {
        public SheduleEditor()
        {
            InitializeComponent();
            InitializeData();
        }
        private void ChangeIssue_Click(object sender, RoutedEventArgs e)
        {
            var dialog = new IssueWindow("Изменить", (Issue)DataGrid_Schedules.SelectedItem);

            if (dialog.ShowDialog() == true)
            {

            }


        }
        private void CreateIssue_Click(object sender, RoutedEventArgs e)
        {
            var dialog = new IssueWindow("Создать");

            if (dialog.ShowDialog() == true)
            {
                ((Schedule)ListBox_ListSchedules.SelectedItem).Issues.Add(dialog.Issue);
            }
            DataGrid_Schedules.Items.Refresh();


        }
        private void Save_Click(object sender, RoutedEventArgs e)
        {

        }
        private void Delete_Click(object sender, RoutedEventArgs e)
        {

        }
        private void SelectedSchedule_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            DataGrid_Schedules.ItemsSource = ((Schedule)ListBox_ListSchedules.SelectedItem).Issues;
        }

        void InitializeData()
        {
            ListBox_ListSchedules.ItemsSource = MainWindow.ScheduleList;
        }

        
    }
}
