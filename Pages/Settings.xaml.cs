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
            slider_basicVolume.Value = MainWindow.SettingsValues.basicVolume * 100;
            slider_middleVolume.Value = MainWindow.SettingsValues.middleVolume * 100;
            slider_introOutroVolume.Value = MainWindow.SettingsValues.introOutroVolume * 100;

            label_basicVolume.Content = $"{Math.Round(slider_basicVolume.Value, 0)}%";
            label_middleVolume.Content = $"{Math.Round(slider_middleVolume.Value, 0)}%";
            label_introOutroVolume.Content = $"{Math.Round(slider_introOutroVolume.Value, 0)}%";

            slider_basicVolume.ValueChanged += slider_ValueChanged;
            slider_middleVolume.ValueChanged += slider_ValueChanged;
            slider_introOutroVolume.ValueChanged += slider_ValueChanged;

            durationTransitionToNormal.Text = MainWindow.SettingsValues.durationTransitionToMiddleVolume.ToString();
            durationTransitionToUp.Text = MainWindow.SettingsValues.durationTransitionToUpVolume.ToString();
            durationTransitionToEnd.Text = MainWindow.SettingsValues.durationTransitionToEndVolume.ToString();
            durationIntroOutroVolume.Text = MainWindow.SettingsValues.durationIntroOutroVolume.ToString();


        }
        private void slider_ValueChanged(object sender, RoutedPropertyChangedEventArgs<double> e)
        {
            MainWindow.SettingsValues.basicVolume = (float)(slider_basicVolume.Value / 100);
            label_basicVolume.Content = $"{Math.Round(slider_basicVolume.Value, 0)}%";

            MainWindow.SettingsValues.middleVolume = (float)(slider_middleVolume.Value / 100);
            label_middleVolume.Content = $"{Math.Round(slider_middleVolume.Value, 0)}%";

            MainWindow.SettingsValues.introOutroVolume = (float)(slider_introOutroVolume.Value / 100);
            label_introOutroVolume.Content = $"{Math.Round(slider_introOutroVolume.Value, 0)}%";
        }

        private void SaveValues_Click(object sender, RoutedEventArgs e)
        {
            var settings = new
            {
                MainWindow.SettingsValues.basicVolume,
                MainWindow.SettingsValues.middleVolume,
                MainWindow.SettingsValues.introOutroVolume,
                MainWindow.SettingsValues.durationTransitionToMiddleVolume,
                MainWindow.SettingsValues.durationTransitionToUpVolume,
                MainWindow.SettingsValues.durationTransitionToEndVolume,
                MainWindow.SettingsValues.durationIntroOutroVolume
            };

            var json = JsonConvert.SerializeObject(settings, Formatting.Indented);

            File.WriteAllText("settings.json", json);
        }

        private void TextBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (int.TryParse(((TextBox)sender).Text, out int result))
            {
                switch (((TextBox)sender).Tag)
                {
                    case "durationTransitionToNormal":
                        MainWindow.SettingsValues.durationTransitionToMiddleVolume = result;
                        break;
                    case "durationTransitionToUp":
                        MainWindow.SettingsValues.durationTransitionToUpVolume = result;
                        break;
                    case "durationTransitionToEnd":
                        MainWindow.SettingsValues.durationTransitionToEndVolume = result;
                        break;
                    case "durationIntroOutroVolume":
                        MainWindow.SettingsValues.durationIntroOutroVolume = result;
                        break;
                }
            }
            
        }
    }
}
