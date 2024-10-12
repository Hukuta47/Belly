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
            slider_Basic.ValueChanged -= Slider_ValueChanged;
            slider_IO.ValueChanged -= Slider_ValueChanged;


            slider_Basic.Value = MainWindow.SettingsValues.normalVolume * 100;
            slider_IO.Value = MainWindow.SettingsValues.introOutroVolume * 100;
            
            BasicLabel.Content = $"{Math.Round(slider_Basic.Value, 0)}%";
            IOLabel.Content = $"{Math.Round(slider_IO.Value, 0)}%";

            slider_Basic.ValueChanged += Slider_ValueChanged;
            slider_IO.ValueChanged += Slider_ValueChanged;
        }
        private void Slider_ValueChanged(object sender, RoutedPropertyChangedEventArgs<double> e)
        {
            MainWindow.SettingsValues.normalVolume = (float)(slider_Basic.Value / 100);
            BasicLabel.Content = $"{Math.Round(slider_Basic.Value, 0)}%";

            MainWindow.SettingsValues.introOutroVolume = (float)(slider_IO.Value / 100);
            IOLabel.Content = $"{Math.Round(slider_IO.Value, 0)}%";
        }

        private void SaveValues_Click(object sender, RoutedEventArgs e)
        {
            var settings = new
            {
                MainWindow.SettingsValues.normalVolume,
                MainWindow.SettingsValues.introOutroVolume
            };

            var json = JsonConvert.SerializeObject(settings, Formatting.Indented);

            File.WriteAllText("settings.json", json);
        }
    }
}
