using Belly.Classes.StaticClasses;
using Belly.Objects;
using System;
using System.Windows;
using System.Windows.Controls;
using System.Collections.Generic;

namespace Belly.Pages
{
    public partial class MainPage : Page
    {
        int TimeMinutes = DateTime.Now.Minute + (DateTime.Now.Hour * 60);

        int DayOfWeek = (int)DateTime.Now.DayOfWeek-1;

        int RealMinutes = DateTime.Now.Minute;
        int RealHours = DateTime.Now.Hour;
        public MainPage()
        {
            InitializeComponent();
            TimeSlider.Value = TimeMinutes;
            WeekTab.SelectedIndex = DayOfWeek;

            List<Schedule> schedules = new List<Schedule>()
            {
                sheduleList.shortSchedule,
                sheduleList.basicSchedule,
                sheduleList.exclusiveSchedule
            };

            Monday_Schedules.ItemsSource = schedules;
            Tuesday_Schedules.ItemsSource = schedules;
            Wednesday_Schedules.ItemsSource = schedules;
            Thursday_Schedules.ItemsSource = schedules;
            Friday_Schedules.ItemsSource = schedules;
            Saturday_Schedules.ItemsSource = schedules;

        }

        private void Slider_ValueChanged(object sender, RoutedPropertyChangedEventArgs<double> e)
        {
            TimeMinutes = (int)TimeSlider.Value;

            RealHours = TimeMinutes / 60;
            RealMinutes = TimeMinutes % 60;

            TimeLabel.Content = $"{RealHours}:{RealMinutes}";
        }

        private void Schedules_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            ComboBox comboBox = (ComboBox)sender;

            switch (comboBox.Name)
            {
                case "Monday_Schedules":
                    Monday_DataGrid.ItemsSource = ((Schedule)Monday_Schedules.SelectedItem).bells;
                    break;
                case "Tuesday_Schedules":
                    Tuesday_DataGrid.ItemsSource = ((Schedule)Tuesday_Schedules.SelectedItem).bells;
                    break;
                case "Wednesday_Schedules":
                    break;
                case "Thursday_Schedules":
                    break;
                case "Friday_Schedules":
                    break;
                case "Saturday_Schedules":
                    break; 



            }

        }
    }
}
