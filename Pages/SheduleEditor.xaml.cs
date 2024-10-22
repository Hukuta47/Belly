using Belly.Objects;
using System.Windows.Controls;
using System.Windows;
using Belly.Dialogs;
using Newtonsoft.Json;
using System.IO;

namespace Belly.Pages
{

    public partial class SheduleEditor : Page
    {
        public SheduleEditor()
        {
            InitializeComponent();
            InitializeData();

            ListBox_ListSchedules.SelectedIndex = 0;
        }
        private void ChangeIssue_Click(object sender, RoutedEventArgs e)
        {
            var dialog = new IssueWindow("Изменить", (Issue)DataGrid_Schedules.SelectedItem);

            if (dialog.ShowDialog() == true)
            {
                ((Schedule)ListBox_ListSchedules.SelectedItem).Issues[DataGrid_Schedules.SelectedIndex] = dialog.Issue;
            }
            DataGrid_Schedules.Items.Refresh();

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
            var json = JsonConvert.SerializeObject(Main.ScheduleList, Formatting.Indented);
            File.WriteAllText("sheduleList.json", json);

        }
        private void Delete_Click(object sender, RoutedEventArgs e)
        {
            Main.ScheduleList[ListBox_ListSchedules.SelectedIndex].Issues.Remove((Issue)DataGrid_Schedules.SelectedItem);
            DataGrid_Schedules.Items.Refresh();
        }
        private void SelectedSchedule_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            DataGrid_Schedules.ItemsSource = ((Schedule)ListBox_ListSchedules.SelectedItem).Issues;
        }

        void InitializeData()
        {
            ListBox_ListSchedules.ItemsSource = Main.ScheduleList;
        }
    }
}
