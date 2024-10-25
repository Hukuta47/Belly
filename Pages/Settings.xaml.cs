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
            slider_basicVolume.Value = Main.SettingsValues.basicVolume * 100;
            slider_middleVolume.Value = Main.SettingsValues.middleVolume * 100;
            slider_introOutroVolume.Value = Main.SettingsValues.introOutroVolume * 100;

            label_basicVolume.Content = $"{Math.Round(slider_basicVolume.Value, 0)}%";
            label_middleVolume.Content = $"{Math.Round(slider_middleVolume.Value, 0)}%";
            label_introOutroVolume.Content = $"{Math.Round(slider_introOutroVolume.Value, 0)}%";

            slider_basicVolume.ValueChanged += slider_ValueChanged;
            slider_middleVolume.ValueChanged += slider_ValueChanged;
            slider_introOutroVolume.ValueChanged += slider_ValueChanged;

            durationTransitionToNormal.Text = Main.SettingsValues.durationTransitionToMiddleVolume.ToString();
            durationTransitionToUp.Text = Main.SettingsValues.durationTransitionToUpVolume.ToString();
            durationTransitionToEnd.Text = Main.SettingsValues.durationTransitionToEndVolume.ToString();
            durationIntroOutroVolume.Text = Main.SettingsValues.durationIntroOutroVolume.ToString();


        }
        private void slider_ValueChanged(object sender, RoutedPropertyChangedEventArgs<double> e)
        {
            Main.SettingsValues.basicVolume = (float)(slider_basicVolume.Value / 100);
            label_basicVolume.Content = $"{Math.Round(slider_basicVolume.Value, 0)}%";

            Main.SettingsValues.middleVolume = (float)(slider_middleVolume.Value / 100);
            label_middleVolume.Content = $"{Math.Round(slider_middleVolume.Value, 0)}%";

            Main.SettingsValues.introOutroVolume = (float)(slider_introOutroVolume.Value / 100);
            label_introOutroVolume.Content = $"{Math.Round(slider_introOutroVolume.Value, 0)}%";



            SaveValues();
        }

        private void SaveValues()
        {
            var settings = new
            {
                Main.SettingsValues.basicVolume,
                Main.SettingsValues.middleVolume,
                Main.SettingsValues.introOutroVolume,
                Main.SettingsValues.durationTransitionToMiddleVolume,
                Main.SettingsValues.durationTransitionToUpVolume,
                Main.SettingsValues.durationTransitionToEndVolume,
                Main.SettingsValues.durationIntroOutroVolume
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
                        Main.SettingsValues.durationTransitionToMiddleVolume = result;
                        break;
                    case "durationTransitionToUp":
                        Main.SettingsValues.durationTransitionToUpVolume = result;
                        break;
                    case "durationTransitionToEnd":
                        Main.SettingsValues.durationTransitionToEndVolume = result;
                        break;
                    case "durationIntroOutroVolume":
                        Main.SettingsValues.durationIntroOutroVolume = result;
                        break;
                }
            }
            SaveValues();
        }
    }
}
