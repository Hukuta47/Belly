
using Belly.Classes.StaticClasses;
using Belly.Objects;
using System.Collections.Generic;
using System.Windows;
using System.Windows.Controls;

namespace Belly.Pages
{
    public partial class MusicEditor : Page
    {
        public MusicEditor()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {

            DataGrid5Min.ItemsSource = new List<Track>() 
            { 
                new Track("C:\\Users\\Hukuu\\Music\\Geoxor - Twilight.mp3"),
                new Track("C:\\Users\\Hukuu\\Music\\Geoxor & poixone - I'm Here.mp3"),
                new Track("C:\\Users\\Hukuu\\Music\\Geoxor - Neon Eyes.mp3"),
                new Track("C:\\Users\\Hukuu\\Music\\Geoxor__Dritic_-_Let_You_Go.mp3")
            };
            DataGrid10Min.ItemsSource = new List<Track>()
            {
                new Track("C:\\Users\\Hukuu\\Music\\Geoxor - Twilight.mp3"),
                new Track("C:\\Users\\Hukuu\\Music\\Geoxor & poixone - I'm Here.mp3"),
                new Track("C:\\Users\\Hukuu\\Music\\Geoxor - Neon Eyes.mp3"),
                new Track("C:\\Users\\Hukuu\\Music\\Geoxor__Dritic_-_Let_You_Go.mp3")
            };
            DataGrid40Min.ItemsSource = new List<Track>()
            {
                new Track("C:\\Users\\Hukuu\\Music\\Geoxor - Twilight.mp3"),
                new Track("C:\\Users\\Hukuu\\Music\\Geoxor & poixone - I'm Here.mp3"),
                new Track("C:\\Users\\Hukuu\\Music\\Geoxor - Neon Eyes.mp3"),
                new Track("C:\\Users\\Hukuu\\Music\\Geoxor__Dritic_-_Let_You_Go.mp3")
            };
        }
        private void SaveClick(object sender, RoutedEventArgs e)
        {
            musicLists.SaveLists
            (
                (List<Track>)DataGrid5Min.ItemsSource, 
                (List<Track>)DataGrid10Min.ItemsSource, 
                (List<Track>)DataGrid40Min.ItemsSource
            );
        }
    }
}
