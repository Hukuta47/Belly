using Belly.Classes.StaticClasses;
using Belly.Objects;
using System.Collections.Generic;
using System.Windows;


namespace Belly.Dialogs
{
    public partial class ChangeBellData : Window
    {
        public Bell SelectedItem;
        public ChangeBellData(object selectedItem)
        {
            InitializeComponent();

            SelectedItem = ((Bell)selectedItem);

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


            TextBox_Name.Text = SelectedItem.Name;
            TextBox_PlayTime.Text = SelectedItem.PlayTime;
            listTracks.SelectedItem = SelectedItem.track;

        }

        private void SaveClick(object sender, RoutedEventArgs e)
        {
            DialogResult = true;

            SelectedItem.Name = TextBox_Name.Text;
            SelectedItem.PlayTime = TextBox_PlayTime.Text;

            if (PrioritySelect.IsChecked == true)
            {
                SelectedItem.track = new SelectTrackPriority(musicLists.Folder5Min);
            }
            else
            {
                SelectedItem.track = (Track)listTracks.SelectedItem;
            }


        }

        private void CancelClick(object sender, RoutedEventArgs e)
        {
            DialogResult = false;
        }
    }
}
