using Belly.Objects;
using System.Windows.Controls;
using System.Windows;
using Belly.Dialogs;

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

        private void CreateIssue_Click(object sender, RoutedEventArgs e)
        {
            var dialog = new IssueWindow("Создать");
            if (dialog.ShowDialog() == true)
            {
                MainWindow.ScheduleList[ListBox_ListSchedules.SelectedIndex].Issues.Add(dialog.Issue);
            }
            DataGrid_Schedules.Items.Refresh();
        }

        private void SelectedSchedule_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            DataGrid_Schedules.ItemsSource = ((Schedule)ListBox_ListSchedules.SelectedItem).Issues;
        }

        private void Save_Click(object sender, RoutedEventArgs e)
        {

        }
    }
}
