
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
            DataGrid5Min.ItemsSource = musicLists.LoadList("5 min\\listInfo.json");
            DataGrid10Min.ItemsSource = musicLists.LoadList("10 min\\listInfo.json");
            DataGrid40Min.ItemsSource = musicLists.LoadList("40 min\\listInfo.json");

        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            musicLists.RefreshLists();
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
