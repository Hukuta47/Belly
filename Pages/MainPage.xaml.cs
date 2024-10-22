using Belly.Objects;
using Newtonsoft.Json;
using System;
using System.IO;
using System.Windows.Controls;

namespace Belly.Pages
{

    public partial class MainPage : Page
    {
        public static Label timeText;
        public static ComboBox selectedShedule;
        public static int dayOfWeel;
        public MainPage()
        {
            InitializeComponent();
            InitializeInterface();
            timeText = TimeLabel;
            TimeLabel.Content = Main.TimeNow.ToString();
            Combobox_SelectSchedule.SelectionChanged += Schedule_SelectionChanged;
            selectedShedule = Combobox_SelectSchedule;
        }
        void InitializeInterface()
        {
            ListBox_WeekList.ItemsSource = Main.Week;
            Combobox_SelectSchedule.ItemsSource = Main.ScheduleList;


            dayOfWeel = (int)DateTime.Now.DayOfWeek - 1;
            if (dayOfWeel <= 5)
            {
                ListBox_WeekList.SelectedIndex = dayOfWeel;
            }
            else
            {
                ListBox_WeekList.SelectedIndex = -1;
            }
        }

        private void DayOfWeekChanged(object sender, SelectionChangedEventArgs e)
        {
            Combobox_SelectSchedule.SelectedIndex = ((Day)ListBox_WeekList.SelectedItem).scheduleNum;
        }
        private void Schedule_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            ((Day)ListBox_WeekList.SelectedItem).scheduleNum = Combobox_SelectSchedule.SelectedIndex;
            File.WriteAllText("weekList.json", JsonConvert.SerializeObject(Main.Week, Formatting.Indented));
        }
    }
}
 