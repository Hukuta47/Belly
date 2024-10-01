using Belly.Classes.StaticClasses;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Belly.Pages
{
    public partial class Settings : Page
    {
        public Settings()
        {
            InitializeComponent();
        }
        void InitializeSettings()
        {

            var jsonRead = File.ReadAllText("settings.json");
            var json = JsonConvert.DeserializeObject<SettingsValues>(jsonRead);

            json.SyncData();
        }
        private void Slider_ValueChanged(object sender, RoutedPropertyChangedEventArgs<double> e)
        {
            if (slider_Basic != null)
            {
                SettingsValues.normalVolume = (float)(slider_Basic.Value / 100);
                if (BasicLabel != null) BasicLabel.Content = $"{Math.Round(slider_Basic.Value, 0)}%";
            }
            if (slider_IO != null)
            {
                SettingsValues.introOutroVolume = (float)(slider_IO.Value / 100);
                if (IOLabel != null) IOLabel.Content = $"{Math.Round(slider_IO.Value, 0)}%";
            }
            Player.SyncSettings();
        }

        private void SaveValues_Click(object sender, RoutedEventArgs e)
        {

        }
    }
}
