using Belly.Classes;
using Belly.Classes.StaticClasses;
using Belly.Objects;
using NAudio.Gui;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.IO;
using System.Windows;
using System.Windows.Controls;


namespace Belly
{

    public partial class MainWindow : Window
    {
        public static SettingsValues SettingsValues;
        public static Player Player;
        public static PageControl pageControl;

        public MainWindow()
        {

            InitializeComponent();
            InitializeFolders();
            InitializeFiles();
            Player = new Player(SettingsValues.normalVolume, SettingsValues.ssintroOutroVolume);
            pageControl = new PageControl(frame);

            Player.SyncSettings();

        }
        void InitializeFolders()
        {
            if (Directory.Exists("Music"))
            {
                Directory.CreateDirectory("Music");
                File.WriteAllText($"Music\\listInfo.json", "[]");
            }
            if (Directory.Exists("Other media")) Directory.CreateDirectory("Other media");

        }
        void InitializeFiles()
        {
            if (!File.Exists("sheduleList.json"))
            {
                List<Schedule> schedules = new List<Schedule>()
                {
                    new Schedule("Обычный день"),
                    new Schedule("Сокращенный день"),
                    new Schedule("Корпоративный день")
                };

                var json = JsonConvert.SerializeObject(schedules, Formatting.Indented);

                File.WriteAllText("sheduleList.json", json);
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
                SettingsValues.ssintroOutroVolume = 0.5f;


                var settings = new
                {
                    SettingsValues.normalVolume,
                    SettingsValues.ssintroOutroVolume
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
                    MainWindow.pageControl.ChangePage(PageControl.Pages.musicEditor);
                    break;
                case "schedule":
                    MainWindow.pageControl.ChangePage(PageControl.Pages.sheduleEditor);
                    break;
                case "main":
                    MainWindow.pageControl.ChangePage(PageControl.Pages.mainPage);
                    break;
                case "settings":
                    MainWindow.pageControl.ChangePage(PageControl.Pages.settings);
                    break;
            }
        }
    }
}
