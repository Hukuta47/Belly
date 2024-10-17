using Belly.Objects;
using System;
using System.Windows;
using System.Windows.Controls;

namespace Belly.Pages
{

    public partial class MainPage : Page
    {
        public static Label timeText;
        public MainPage()
        {
            InitializeComponent();
            InitializeInterface();
            timeText = TimeLabel;
            TimeLabel.Content = MainWindow.TimeNow.ToString();
            Combobox_SelectSchedule.SelectionChanged += Schedule_SelectionChanged;

        }
        void InitializeInterface()
        {
            ListBox_WeekList.ItemsSource = MainWindow.Week;
            Combobox_SelectSchedule.ItemsSource = MainWindow.ScheduleList;


            int _numDay = (int)DateTime.Now.DayOfWeek - 1;
            if (_numDay <= 5)
            {
                ListBox_WeekList.SelectedIndex = _numDay;
            }
            else
            {
                ListBox_WeekList.SelectedIndex = -1;
            }
        }

        private void DayOfWeekChanged(object sender, SelectionChangedEventArgs e)
        {
            Combobox_SelectSchedule.SelectedItem = ((Day)ListBox_WeekList.SelectedItem).Schedule;
        }
        private void Schedule_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            ((Day)ListBox_WeekList.SelectedItem).Schedule = (Schedule)Combobox_SelectSchedule.SelectedItem;
            DataGrid_IssueList.ItemsSource = ((Schedule)Combobox_SelectSchedule.SelectedItem).Issues;
        }
        public void ResetData()
        {
            //DataGrid_IssueList = null;

        }
        public void RecoveryData()
        {
            //if ((Schedule)Combobox_SelectSchedule.SelectedItem != null) DataGrid_IssueList.ItemsSource = ((Schedule)Combobox_SelectSchedule.SelectedItem).Issues;
        }
    }
}
 