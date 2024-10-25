using Belly.Objects;
using System.Windows.Controls;
using System.Windows;
using Belly.Dialogs;
using Newtonsoft.Json;
using System.IO;
using Microsoft.VisualBasic;

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
            SaveSchedule();

            
        }
        private void CreateIssue_Click(object sender, RoutedEventArgs e)
        {
            var dialog = new IssueWindow("Создать");

            if (dialog.ShowDialog() == true)
            {
                ((Schedule)ListBox_ListSchedules.SelectedItem).Issues.Add(dialog.Issue);
            }
            DataGrid_Schedules.Items.Refresh();
            SaveSchedule();

        }
        
        private void Delete_Click(object sender, RoutedEventArgs e)
        {
            foreach (Issue issue in DataGrid_Schedules.SelectedItems)
            {
                Main.ScheduleList[ListBox_ListSchedules.SelectedIndex].Issues.Remove(issue);
            }
            DataGrid_Schedules.Items.Refresh();
            SaveSchedule();
        }
        private void SelectedSchedule_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            DataGrid_Schedules.ItemsSource = ((Schedule)ListBox_ListSchedules.SelectedItem).Issues;

            button_changeIssue.IsEnabled = false;
            button_deleteIssue.IsEnabled = false;
            button_unselect.IsEnabled = false;
        }

        void InitializeData()
        {
            ListBox_ListSchedules.ItemsSource = Main.ScheduleList;
        }
        private void SaveSchedule()
        {
            var json = JsonConvert.SerializeObject(Main.ScheduleList, Formatting.Indented);
            File.WriteAllText("sheduleList.json", json);
        }

        private void DataGrid_Schedules_SelectedCellsChanged(object sender, SelectedCellsChangedEventArgs e)
        {
            DataGrid dataGrid = (DataGrid)sender;
            if (dataGrid.SelectedItems.Count > 1)
            {
                button_changeIssue.IsEnabled = false;
            }
            else
            {
                button_changeIssue.IsEnabled = true;
            }

            if (dataGrid.SelectedItems.Count > 0)
            {
                button_unselect.IsEnabled = true;
                button_deleteIssue.IsEnabled = true;
            }
            else if (dataGrid.SelectedItems.Count < 0)
            {
                button_deleteIssue.IsEnabled = false;
                button_unselect.IsEnabled = false;
            }
        }

        private void unselect_Click(object sender, RoutedEventArgs e)
        {
            DataGrid_Schedules.SelectedItem = null;
            button_unselect.IsEnabled = false;
            button_changeIssue.IsEnabled = false;
            button_deleteIssue.IsEnabled = false;
        }
    }
}
