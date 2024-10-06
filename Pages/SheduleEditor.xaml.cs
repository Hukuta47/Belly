using Belly.Objects;
using System.Windows.Controls;
using System.Windows;
using Belly.Dialogs;
using Newtonsoft.Json;
using System.IO;
using System.Diagnostics.Metrics;

namespace Belly.Pages
{

    public partial class SheduleEditor : Page
    {
        public SheduleEditor()
        {
            InitializeComponent();
            InitializeSchedules();
        }
        void InitializeSchedules()
        {
            ListBox_ListSchedules.ItemsSource = MainWindow.ScheduleList;
        }

        

        private void SelectedSchedule_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            DataGrid_Schedules.ItemsSource = ((Schedule)ListBox_ListSchedules.SelectedItem).Issues;
        }

        private void Save_Click(object sender, RoutedEventArgs e)
        {
            var jsonReady = JsonConvert.SerializeObject(MainWindow.ScheduleList, Formatting.Indented);

            File.WriteAllText("sheduleList.json", jsonReady);
        }
        private void CreateIssue_Click(object sender, RoutedEventArgs e)
        {
            var dialog = new IssueWindow("Создать");
            if (dialog.ShowDialog() == true)
            {
                MainWindow.ScheduleList[ListBox_ListSchedules.SelectedIndex].Issues.Add(dialog.Issue);
            }
            DataGrid_Schedules.Items.Refresh();
        }

        private void ChangeIssue_Click(object sender, RoutedEventArgs e)
        {
            var dialog = new IssueWindow("Изменить", (Issue)DataGrid_Schedules.SelectedItem);

            var issuesList = MainWindow.ScheduleList[ListBox_ListSchedules.SelectedIndex].Issues;
            int index = issuesList.FindIndex(obj => obj.Name == dialog.Issue.Name);

            if (dialog.ShowDialog() == true)
            {
                if (index != -1)
                {
                    issuesList[index] = dialog.Issue;
                }
            }
            DataGrid_Schedules.Items.Refresh();
        }

        private void Delete_Click(object sender, RoutedEventArgs e)
        {
            MainWindow.ScheduleList[ListBox_ListSchedules.SelectedIndex].Issues.Remove((Issue)DataGrid_Schedules.SelectedItem);
            DataGrid_Schedules.Items.Refresh();
        }
    }
}
