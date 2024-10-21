using Belly.Classes;
using Belly.Classes.StaticClasses;
using Belly.Objects;
using Belly.Pages;
using Newtonsoft.Json;
using NAudio.Wave;
using System;
using System.Collections.Generic;
using System.IO;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;


namespace Belly
{

    public partial class MainWindow : Window
    {
        public static SettingsValues SettingsValues;
        public static Player Player;
        public static PageControl pageControl;
        public static TimeOnly TimeNow;
        public static List<Music> MusicList;
        public static List<Audio> AudioList;
        public static List<Schedule> ScheduleList;
        public static List<Day> Week;
        bool initialized = false;
        bool messageShown = false;



        public MainWindow()
        {
            InitializeComponent();
            InitializeTime();
            InitializeFolders();
            InitializeFiles();
            InitializeClasses();
            


            pageControl.ChangePage(PageControl.Pages.mainPage);

            initialized = true;
        }
        async void InitializeTime()
        {
            await syncTime();
        }
        void InitializeFolders()
        {
            if (!Directory.Exists("Music")) Directory.CreateDirectory("Music");
            if (!File.Exists($"Music\\listInfo.json")) File.WriteAllText($"Music\\listInfo.json", "[]");
            
            if (!Directory.Exists("Audio")) Directory.CreateDirectory("Audio");

        }
        void InitializeClasses()
        {
            SettingsValues = JsonConvert.DeserializeObject<SettingsValues>(File.ReadAllText("settings.json"));
            MusicList = JsonConvert.DeserializeObject<List<Music>>(File.ReadAllText(@"Music\\listInfo.json"));
            Week = JsonConvert.DeserializeObject<List<Day>>(File.ReadAllText("weekList.json"));
            
            Player = new Player(SettingsValues.normalVolume, SettingsValues.introOutroVolume);

            AudioList = new List<Audio>(new DirectoryInfo("Audio").GetFiles("*.mp3").Length);
            

            foreach (FileInfo file in new DirectoryInfo("Audio").GetFiles("*.mp3"))
            {
                AudioList.Add(new Audio(file.FullName));
            }

            

            pageControl = new PageControl(frame);

            
        }
        void InitializeFiles()
        {
            if (!File.Exists("sheduleList.json"))
            {
                ScheduleList = new List<Schedule>()
                {
                    new Schedule("Обычный день"),
                    new Schedule("Сокращенный день"),
                    new Schedule("Корпоративный день")
                };

                var json = JsonConvert.SerializeObject(ScheduleList, Formatting.Indented);

                File.WriteAllText("sheduleList.json", json);
            }
            else
            {
                ScheduleList = JsonConvert.DeserializeObject<List<Schedule>>(File.ReadAllText("sheduleList.json"));
            }

            if (!File.Exists("weekList.json"))
            {
                Week = new List<Day>
                {
                    new Day(DayOfWeek.Monday),
                    new Day(DayOfWeek.Tuesday),
                    new Day(DayOfWeek.Wednesday),
                    new Day(DayOfWeek.Thursday),
                    new Day(DayOfWeek.Friday),
                    new Day(DayOfWeek.Saturday)
                };

                var json = JsonConvert.SerializeObject(Week, Formatting.Indented);

                File.WriteAllText("weekList.json", json);
            }
            if (!File.Exists("settings.json"))
            {
                SettingsValues = new();

                SettingsValues.normalVolume = 0.5f;
                SettingsValues.introOutroVolume = 0.5f;


                var settings = new
                {
                    SettingsValues.normalVolume,
                    SettingsValues.introOutroVolume
                };

                var json = JsonConvert.SerializeObject(settings, Formatting.Indented);

                File.WriteAllText("settings.json", json);
            }
        }
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            Button button = (Button)sender;
            switch (button.Tag)
            {

                case "music":
                    pageControl.ChangePage(PageControl.Pages.musicEditor);
                    break;
                case "schedule":
                    pageControl.ChangePage(PageControl.Pages.sheduleEditor);
                    break;
                case "main":
                    pageControl.ChangePage(PageControl.Pages.mainPage);
                    break;
                case "settings":
                    pageControl.ChangePage(PageControl.Pages.settings);
                    break;
            }
        }
        async Task syncTime()
        {
            while (true)
            {

                TimeNow = new TimeOnly(DateTime.Now.Hour, DateTime.Now.Minute, DateTime.Now.Second);
                if (MainPage.timeText != null) MainPage.timeText.Content = TimeNow.ToString();



                if (initialized == true)
                {
                    Schedule schedule = (Schedule)pageControl.mainPage.Combobox_SelectSchedule.SelectedItem;
                    if (schedule.Issues != null)
                    {

                        foreach (Issue item in schedule.Issues)
                        {
                            if (item.StartTime.ToTimeSpan().TotalSeconds == TimeNow.ToTimeSpan().TotalSeconds && 
                                !messageShown && Player.OutputDevice.PlaybackState != PlaybackState.Playing
                                )
                            {

                                item.Start();
                                messageShown = true; // Фиксируем, что сообщение показано
                            }

                            // Если время больше не совпадает, сбрасываем флаг
                            if (item.StartTime.ToTimeSpan().TotalSeconds != TimeNow.ToTimeSpan().TotalSeconds)
                            {
                                messageShown = false;
                            }
                        }
                    }

                }


                await Task.Delay(50);

            }
        }
    }
}
