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
            InitializeSettings();
        }
        void InitializeSettings()
        {

            var jsonRead = File.ReadAllText("settings.json");
            MainWindow.SettingsValues = JsonConvert.DeserializeObject<SettingsValues>(jsonRead);

            slider_Basic.Value = MainWindow.SettingsValues.normalVolume * 100;
            slider_IO.Value = MainWindow.Player._settings.ssintroOutroVolume * 100;

        }
        private void Slider_ValueChanged(object sender, RoutedPropertyChangedEventArgs<double> e)
        {
            if (slider_Basic != null)
            {
                MainWindow.SettingsValues.normalVolume = (float)(slider_Basic.Value / 100);
                if (BasicLabel != null) BasicLabel.Content = $"{Math.Round(slider_Basic.Value, 0)}%";
            }
            if (slider_IO != null)
            {
                MainWindow.SettingsValues.ssintroOutroVolume = (float)(slider_IO.Value / 100);
                if (IOLabel != null) IOLabel.Content = $"{Math.Round(slider_IO.Value, 0)}%";
            }
            MainWindow.Player.SyncSettings();
        }

        private void SaveValues_Click(object sender, RoutedEventArgs e)
        {
            var settings = new
            {
                MainWindow.SettingsValues.normalVolume,
                MainWindow.SettingsValues.ssintroOutroVolume
            };

            var json = JsonConvert.SerializeObject(settings, Formatting.Indented);

            File.WriteAllText("settings.json", json);
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
