using Belly.Classes;
using Belly.Classes.StaticClasses;
using Belly.Objects;
using Belly.Pages;
using Newtonsoft.Json;
using NAudio.Wave;
using System;
using System.Collections.Generic;
using System.Diagnostics;
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
            if (!Directory.Exists("Icons")) Directory.CreateDirectory("Icons");

        }
        void InitializeClasses()
        {
            Player = new Player(SettingsValues.basicVolume);

            MusicList = JsonConvert.DeserializeObject<List<Music>>(File.ReadAllText(@"Music\\listInfo.json"));
            AudioList = new List<Audio>(new DirectoryInfo("Audio").GetFiles("*.mp3").Length);

            pageControl = new PageControl(frame);

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
            else
            {
                Week = JsonConvert.DeserializeObject<List<Day>>(File.ReadAllText("weekList.json"));
            }
            if (!File.Exists("settings.json"))
            {
                SettingsValues = new();

                SettingsValues.basicVolume = 0.5f;
                SettingsValues.middleVolume = 0.5f;
                SettingsValues.introOutroVolume = 0.5f;

                SettingsValues.durationIntroOutroVolume = 1;
                SettingsValues.durationTransitionToMiddleVolume = 1;
                SettingsValues.durationTransitionToUpVolume = 1;
                SettingsValues.durationTransitionToEndVolume = 1;


                var settings = new
                {
                    SettingsValues.basicVolume,
                    SettingsValues.middleVolume,
                    SettingsValues.introOutroVolume,

                    SettingsValues.durationIntroOutroVolume,
                    SettingsValues.durationTransitionToMiddleVolume,
                    SettingsValues.durationTransitionToUpVolume,
                    SettingsValues.durationTransitionToEndVolume
            };

                var json = JsonConvert.SerializeObject(settings, Formatting.Indented);

                File.WriteAllText("settings.json", json);
            }
            else
            {
                var jsonRead = File.ReadAllText("settings.json");
                SettingsValues = JsonConvert.DeserializeObject<SettingsValues>(jsonRead);
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
                if (TimeNow != TimeOnly.FromDateTime(DateTime.Now))
                {
                    TimeNow = TimeOnly.FromDateTime(DateTime.Now);
                    if (MainPage.timeText != null) MainPage.timeText.Content = TimeNow.ToString();



                    if (initialized == true)
                    {
                        Schedule schedule = (Schedule)MainPage.selectedShedule.SelectedItem;
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
                    Debug.WriteLine(TimeNow.Minute);
                    await Task.Delay(100);
                }
            }
        }
    }
}
