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

        }
        void InitializeInterface()
        {
            ListBox_WeekList.ItemsSource = MainWindow.Week;
            Combobox_SelectSchedule.ItemsSource = MainWindow.ScheduleList;

        }

        private void DayOfWeekChanged(object sender, SelectionChangedEventArgs e)
        {
            Combobox_SelectSchedule.SelectedItem = ((Day)ListBox_WeekList.SelectedItem).Schedule;
        }
    }
}
 