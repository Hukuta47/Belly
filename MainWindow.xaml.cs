using Belly.Classes;
using Belly.Classes.StaticClasses;
using Belly.Objects;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.IO;
using System.Windows;
using System.Windows.Controls;


namespace Belly
{

    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            InitializeFolders();
            InitializeFiles();
            PageControl.mainFrame = frame;

        }
        void InitializeFolders()
        {
            List<string> list = new List<string>()
            {
                "5 min",
                "10 min",
                "40 min"
            };
            foreach (string folder in list)
            {
                if (!Directory.Exists(folder))
                {
                    Directory.CreateDirectory(folder);
                    File.WriteAllText($"{folder}\\listInfo.json", "[]");
                }
            }
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
                var json = JsonConvert.SerializeObject(new weekList(), Formatting.Indented);

                File.WriteAllText("weekList.json", json);
            }
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            Button button = (Button)sender;


            switch (button.Tag)
            {
                case "music":
                    PageControl.ChangePage(PageControl.Pages.musicEditor);
                    break;
                case "schedule":
                    PageControl.ChangePage(PageControl.Pages.sheduleEditor);
                    break;
                case "main":
                    PageControl.ChangePage(PageControl.Pages.mainPage);
                    break;
            }
        }
    }
}
