using Belly.Objects;
using System.Windows.Controls;

namespace Belly.Pages
{

    public partial class MainPage : Page
    {
        public static Label timeText;
        RadioButton selectedRadioButton;
        public MainPage()
        {
            InitializeComponent();
            InitializeInterface();
            timeText = TimeLabel;
            TimeLabel.Content = MainWindow.TimeNow.ToString();
        }
        void InitializeInterface()
        {
            Combobox_SelectSchedule.ItemsSource = MainWindow.ScheduleList;
            selectedRadioButton = RadioButton_Monday;
            RadioButton_Monday.IsChecked = true;
            RadioButton_Monday.Checked += RadioButton_Click;
            Combobox_SelectSchedule.SelectedItem = MainWindow.Week[0].Schedule;
            Combobox_SelectSchedule.SelectionChanged += Combobox_SelectSchedule_SelectionChanged;

        }

        private void RadioButton_Click(object sender, System.Windows.RoutedEventArgs e)
        {
            selectedRadioButton = (RadioButton)sender;
            switch (selectedRadioButton.Tag)
            {
                case "Monday": Combobox_SelectSchedule.SelectedItem = MainWindow.Week[0].Schedule; break;
                case "Tuesday": Combobox_SelectSchedule.SelectedItem = MainWindow.Week[1].Schedule; break;
                case "Wednesday": Combobox_SelectSchedule.SelectedItem = MainWindow.Week[2].Schedule; break;
                case "Thursday": Combobox_SelectSchedule.SelectedItem = MainWindow.Week[3].Schedule; break;
                case "Friday": Combobox_SelectSchedule.SelectedItem = MainWindow.Week[4].Schedule; break;
                case "Saturday": Combobox_SelectSchedule.SelectedItem = MainWindow.Week[5].Schedule; break;
            }
        }

        private void Combobox_SelectSchedule_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            switch (selectedRadioButton.Tag)
            {
                case "Monday": MainWindow.Week[0].Schedule = (Schedule)Combobox_SelectSchedule.SelectedItem; break;
                case "Tuesday": MainWindow.Week[1].Schedule = (Schedule)Combobox_SelectSchedule.SelectedItem; break;
                case "Wednesday": MainWindow.Week[2].Schedule = (Schedule)Combobox_SelectSchedule.SelectedItem; break;
                case "Thursday": MainWindow.Week[3].Schedule = (Schedule)Combobox_SelectSchedule.SelectedItem; break;
                case "Friday": MainWindow.Week[4].Schedule = (Schedule)Combobox_SelectSchedule.SelectedItem; break;
                case "Saturday": MainWindow.Week[5].Schedule = (Schedule)Combobox_SelectSchedule.SelectedItem; break;

            }
        }
    }
}
 