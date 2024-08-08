using Belly.Classes.StaticClasses;
using Belly.Objects;
using System;
using System.Collections.Generic;
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
using System.Windows.Shapes;

namespace Belly.Dialogs
{
    public partial class ChangeBellData : Window
    {
        public ChangeBellData()
        {
            InitializeComponent();

            List<Track> tracks = new List<Track>();
            
            foreach (Track track in musicLists.Folder5Min)
            {
                tracks.Add(track);
            }
            foreach (Track track in musicLists.Folder10Min)
            {
                tracks.Add(track);
            }
            foreach (Track track in musicLists.Folder40Min)
            {
                tracks.Add(track);
            }

            listTracks.ItemsSource = tracks;
        }

        private void SaveClick(object sender, RoutedEventArgs e)
        {
            DialogResult = true;
        }

        private void CancelClick(object sender, RoutedEventArgs e)
        {
            DialogResult = false;
        }
    }
}
