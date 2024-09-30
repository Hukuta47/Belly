using Belly.Classes.StaticClasses;
using Newtonsoft.Json;
using System;
using System.IO;
using System.Windows;
using System.Windows.Controls;

namespace Belly.Pages
{
    public partial class Settings : Page
    {
        public Settings()
        {
            InitializeComponent();
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

        private void SaveSettings_Click(object sender, RoutedEventArgs e)
        {
            var settingsVolume = new
            {
                SettingsValues.introOutroVolume,
                SettingsValues.normalVolume
            };

            string jsonReady = JsonConvert.SerializeObject(settingsVolume, Formatting.Indented);

            File.WriteAllText("settings.json", jsonReady);

        }
    }
}
