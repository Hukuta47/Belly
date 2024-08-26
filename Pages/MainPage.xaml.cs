using Belly.Classes.StaticClasses;
using Belly.Objects;
using System;
using System.Windows;
using NAudio.Wave;
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


        Mp3FileReader reader;
        WaveOut waveOut;

        public MainPage()
        {
            InitializeComponent();
            

            List<Schedule> schedules = new List<Schedule>()
            {
                
                sheduleList.basicSchedule,
                sheduleList.shortSchedule,
                sheduleList.exclusiveSchedule
            };

            Monday_Schedules.ItemsSource = schedules;
            Tuesday_Schedules.ItemsSource = schedules;
            Wednesday_Schedules.ItemsSource = schedules;
            Thursday_Schedules.ItemsSource = schedules;
            Friday_Schedules.ItemsSource = schedules;
            Saturday_Schedules.ItemsSource = schedules;


            Monday_Schedules.SelectedIndex = 0;

                                

            TimeSlider.Value = TimeMinutes;
            WeekTab.SelectedIndex = DayOfWeek;
        }

        private void Slider_ValueChanged(object sender, RoutedPropertyChangedEventArgs<double> e)
        {
            TimeMinutes = (int)TimeSlider.Value;

            RealHours = TimeMinutes / 60;
            RealMinutes = TimeMinutes % 60;

            TimeLabel.Content = $"{RealHours}:{RealMinutes}";


            switch (DayOfWeek)
            {
                case 0: playMediaAtTime(Monday_DataGrid); break;
                case 1: playMediaAtTime(Tuesday_DataGrid); break;
                case 2: playMediaAtTime(Wednesday_DataGrid); break;
                case 3: playMediaAtTime(Thursday_DataGrid); break;
                case 4: playMediaAtTime(Friday_DataGrid); break;
                case 5: playMediaAtTime(Saturday_DataGrid); break;
            }



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
                    Wednesday_DataGrid.ItemsSource = ((Schedule)Wednesday_Schedules.SelectedItem).bells;
                    break;
                case "Thursday_Schedules":
                    Thursday_DataGrid.ItemsSource = ((Schedule)Thursday_Schedules.SelectedItem).bells;
                    break; 
                case "Friday_Schedules":
                    Friday_DataGrid.ItemsSource = ((Schedule)Friday_Schedules.SelectedItem).bells;
                    break;
                case "Saturday_Schedules":
                    Saturday_DataGrid.ItemsSource = ((Schedule)Saturday_Schedules.SelectedItem).bells;
                    break; 

            }

        }

        void playMediaAtTime(DataGrid dataGrid)
        {
            foreach (Bell bell in (List<Bell>)dataGrid.ItemsSource)
            {
                if (bell.PlayTime == $"{RealHours}:{RealMinutes}")
                {

                    switch (bell.Media.typeData)
                    {
                        case Enums.TypeData.Track:

                            reader = new Mp3FileReader(((Track)bell.Media).Path);
                            waveOut = new WaveOut();
                            waveOut.Init(reader);
                            waveOut.Play();

                            break;
                        case Enums.TypeData.Folder:


                            reader = new Mp3FileReader(((Folder)bell.Media).GetPriorityPath(musicLists.Min5));
                            waveOut = new WaveOut();
                            waveOut.Init(reader);
                            waveOut.Play();
                            break;
                    }
                }
            }
        }
    }
}
