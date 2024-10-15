using Belly.Objects;
using System.Windows.Controls;

namespace Belly.Pages
{

    public partial class MainPage : Page
    {
        public static Label timeText;
        public MainPage()
        {
            InitializeComponent();
            timeText = TimeLabel;
            TimeLabel.Content = MainWindow.TimeNow.ToString();

            //ListBox_Schedules.ItemsSource = MainWindow.ScheduleList;
        }

        private void ListBox_Schedules_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }

        private void TabControl_weekList_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }
    }
}
 