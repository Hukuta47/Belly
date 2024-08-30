using Belly.Classes.StaticClasses;
using Belly.Objects;
using System;
using System.Windows;
using NAudio.Wave;
using System.Windows.Controls;
using System.Collections.Generic;
using Newtonsoft.Json;
using System.IO;
using System.Windows.Threading;

namespace Belly.Pages
{

    public partial class MainPage : Page
    {
        private DispatcherTimer _timer;



        int TimeMinutes = (int)DateTime.Now.TimeOfDay.TotalMinutes;

        int DayOfWeek = (int)DateTime.Now.DayOfWeek - 1;

        int RealMinutes = DateTime.Now.Minute;
        int RealHours = DateTime.Now.Hour;


        Mp3FileReader reader;
        WaveOut waveOut;

        public MainPage()
        {
            InitializeComponent();
            InitializeTimer();


            List<Schedule> schedules = new List<Schedule>()
            {
                sheduleList.basicSchedule,
                sheduleList.shortSchedule,
                sheduleList.exclusiveSchedule
            };

            weekList.Week = JsonConvert.DeserializeObject<List<int>>(File.ReadAllText("weekList.json"));


            Monday_Schedules.ItemsSource = schedules;
            Tuesday_Schedules.ItemsSource = schedules;
            Wednesday_Schedules.ItemsSource = schedules;
            Thursday_Schedules.ItemsSource = schedules;
            Friday_Schedules.ItemsSource = schedules;
            Saturday_Schedules.ItemsSource = schedules;

            Monday_Schedules.SelectedIndex = weekList.Week[0];
            Tuesday_Schedules.SelectedIndex = weekList.Week[1];
            Wednesday_Schedules.SelectedIndex = weekList.Week[2];
            Thursday_Schedules.SelectedIndex = weekList.Week[3];
            Friday_Schedules.SelectedIndex = weekList.Week[4];
            Saturday_Schedules.SelectedIndex = weekList.Week[5];





            TimeSlider.Value = TimeMinutes;
            WeekTab.SelectedIndex = DayOfWeek;
        }

        private void Slider_ValueChanged(object sender, RoutedPropertyChangedEventArgs<double> e)
        {
            TimeMinutes = (int)TimeSlider.Value;

            RealHours = TimeMinutes / 60;
            RealMinutes = TimeMinutes % 60;

            TimeLabel.Content = Time();


            switch (DayOfWeek)
            {
                case 0: playMediaAtTime((List<Bell>)Monday_DataGrid.ItemsSource); break;
                case 1: playMediaAtTime((List<Bell>)Tuesday_DataGrid.ItemsSource); break;
                case 2: playMediaAtTime((List<Bell>)Wednesday_DataGrid.ItemsSource); break;
                case 3: playMediaAtTime((List<Bell>)Thursday_DataGrid.ItemsSource); break;
                case 4: playMediaAtTime((List<Bell>)Friday_DataGrid.ItemsSource); break;
                case 5: playMediaAtTime((List<Bell>)Saturday_DataGrid.ItemsSource); break;
            }
        }

        private void Schedules_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            ComboBox comboBox = (ComboBox)sender;

            switch (comboBox.Name)
            {
                case "Monday_Schedules": Monday_DataGrid.ItemsSource = ((Schedule)Monday_Schedules.SelectedItem).bells; break;
                case "Tuesday_Schedules": Tuesday_DataGrid.ItemsSource = ((Schedule)Tuesday_Schedules.SelectedItem).bells; break;
                case "Wednesday_Schedules": Wednesday_DataGrid.ItemsSource = ((Schedule)Wednesday_Schedules.SelectedItem).bells; break;
                case "Thursday_Schedules": Thursday_DataGrid.ItemsSource = ((Schedule)Thursday_Schedules.SelectedItem).bells; break;
                case "Friday_Schedules": Friday_DataGrid.ItemsSource = ((Schedule)Friday_Schedules.SelectedItem).bells; break;
                case "Saturday_Schedules": Saturday_DataGrid.ItemsSource = ((Schedule)Saturday_Schedules.SelectedItem).bells; break;

            }

        }

        void playMediaAtTime(List<Bell> Bells)
        {
            foreach (Bell bell in Bells)
            {
                if (bell.PlayTime == Time())
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

        private void SaveWeek_Click(object sender, RoutedEventArgs e)
        {
            weekList.Week = new List<int>
            {
                Monday_Schedules.SelectedIndex,
                Tuesday_Schedules.SelectedIndex,
                Wednesday_Schedules.SelectedIndex,
                Thursday_Schedules.SelectedIndex,
                Friday_Schedules.SelectedIndex,
                Saturday_Schedules.SelectedIndex
            };



            var json = JsonConvert.SerializeObject(weekList.Week, Formatting.Indented);
            File.WriteAllText("weekList.json", json);

        }

        string Time()
        {
            if (RealHours <= 9 && RealMinutes <= 9) return $"0{RealHours}:0{RealMinutes}";
            else if (RealHours <= 9 && RealMinutes >= 9) return $"0{RealHours}:{RealMinutes}";
            else if (RealHours >= 9 && RealMinutes <= 9) return $"{RealHours}:0{RealMinutes}";
            else if (RealHours >= 9 && RealMinutes >= 9) return $"{RealHours}:{RealMinutes}";

            return "";
        }

        private void InitializeTimer()
        {
            // Рассчитаем время до начала следующей минуты
            DateTime now = DateTime.Now;
            int secondsUntilNextMinute = 60 - now.Second;
            TimeSpan timeToNextMinute = TimeSpan.FromSeconds(secondsUntilNextMinute);

            // Создаем и запускаем таймер на оставшееся время до начала следующей минуты
            _timer = new DispatcherTimer();
            _timer.Interval = timeToNextMinute;
            _timer.Tick += SyncWithRealTime;
            _timer.Start();
        }
        private void SyncWithRealTime(object sender, EventArgs e)
        {
            // Останавливаем текущий таймер
            _timer.Stop();

            // Действия, которые нужно выполнить в начале каждой минуты

            TimeMinutes = (int)DateTime.Now.TimeOfDay.TotalMinutes;

            if (DayOfWeek != (int)DateTime.Now.DayOfWeek - 1)
            {
                DayOfWeek = (int)DateTime.Now.DayOfWeek - 1;
                WeekTab.SelectedIndex = DayOfWeek;
            }

            RealHours = TimeMinutes / 60;
            RealMinutes = TimeMinutes % 60;

            TimeLabel.Content = Time();


            switch (DayOfWeek)
            {
                case 0: playMediaAtTime((List<Bell>)Monday_DataGrid.ItemsSource); break;
                case 1: playMediaAtTime((List<Bell>)Tuesday_DataGrid.ItemsSource); break;
                case 2: playMediaAtTime((List<Bell>)Wednesday_DataGrid.ItemsSource); break;
                case 3: playMediaAtTime((List<Bell>)Thursday_DataGrid.ItemsSource); break;
                case 4: playMediaAtTime((List<Bell>)Friday_DataGrid.ItemsSource); break;
                case 5: playMediaAtTime((List<Bell>)Saturday_DataGrid.ItemsSource); break;
            }



            // Настраиваем таймер на повторение каждые 60 секунд
            _timer.Interval = TimeSpan.FromMinutes(1);
            _timer.Tick -= SyncWithRealTime; // Отвязываем предыдущий обработчик
            _timer.Tick += Timer_Tick;
            _timer.Start();
        }

        private void Timer_Tick(object sender, EventArgs e)
        {
            TimeMinutes = (int)DateTime.Now.TimeOfDay.TotalMinutes;

            if (DayOfWeek != (int)DateTime.Now.DayOfWeek - 1)
            {
                DayOfWeek = (int)DateTime.Now.DayOfWeek - 1;
                WeekTab.SelectedIndex = DayOfWeek;
            }

            RealHours = TimeMinutes / 60;
            RealMinutes = TimeMinutes % 60;

            TimeLabel.Content = Time();


            switch (DayOfWeek)
            {
                case 0: playMediaAtTime((List<Bell>)Monday_DataGrid.ItemsSource); break;
                case 1: playMediaAtTime((List<Bell>)Tuesday_DataGrid.ItemsSource); break;
                case 2: playMediaAtTime((List<Bell>)Wednesday_DataGrid.ItemsSource); break;
                case 3: playMediaAtTime((List<Bell>)Thursday_DataGrid.ItemsSource); break;
                case 4: playMediaAtTime((List<Bell>)Friday_DataGrid.ItemsSource); break;
                case 5: playMediaAtTime((List<Bell>)Saturday_DataGrid.ItemsSource); break;
            }
        }


    }
}
 