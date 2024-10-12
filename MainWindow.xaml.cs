using Belly.Classes;
using Belly.Classes.StaticClasses;
using Belly.Objects;
using Belly.Pages;
using NAudio.Mixer;
using Newtonsoft.Json;
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



        public MainWindow()
        {

            InitializeComponent();
            InitializeTime();
            InitializeFolders();
            InitializeFiles();
            InitializeClasses();



        }
        async void InitializeTime()
        {
            await syncTime();
        }
        void InitializeFolders()
        {
            if (!Directory.Exists("Music"))
            {
                Directory.CreateDirectory("Music");
                File.WriteAllText($"Music\\listInfo.json", "[]");
            }
            if (!Directory.Exists("Audio")) Directory.CreateDirectory("Audio");

        }
        void InitializeClasses()
        {
            Player = new Player(SettingsValues.normalVolume, SettingsValues.introOutroVolume);
            pageControl = new PageControl(frame);

            MusicList = JsonConvert.DeserializeObject<List<Music>>(File.ReadAllText("Music\\listInfo.json"));
            AudioList = new List<Audio>(new DirectoryInfo("Audio").GetFiles("*.mp3").Length);


            foreach (FileInfo file in new DirectoryInfo("Audio").GetFiles("*.mp3"))
            {
                AudioList.Add(new Audio(file.FullName));
            }

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
                var json = JsonConvert.SerializeObject(weekList.Week, Formatting.Indented);

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
                }
                Debug.WriteLine(TimeNow.Minute);
                await Task.Delay(100);
            }
        }
    }
}
