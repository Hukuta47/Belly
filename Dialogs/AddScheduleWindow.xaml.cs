using Belly.Classes.StaticClasses;
using Belly.Objects;
using System.Collections.Generic;
using System.Windows;


namespace Belly.Dialogs
{
    public partial class AddScheduleWindow : Window
    {
        public string Name;
        public string PlayTime;
        public MediaFile MediaData;
        public AddScheduleWindow()
        {
            InitializeComponent();


            List<List<Music>> trackLists = new List<List<Music>>()
            {
                musicLists.Min5,
                musicLists.Min10,
                musicLists.Min40
            };
            List<Music> tmpTracks = new List<Music>();

            foreach (List<Music> list in trackLists)
            {
                foreach (Music track in list)
                {
                    tmpTracks.Add(track);
                }
            }

            //listObjects.DisplayMemberPath = "Path";
            listObjects.ItemsSource = tmpTracks;





        }

        private void Create_Click(object sender, RoutedEventArgs e)
        {
            DialogResult = true;

            Name = TextBox_Name.Text;
            PlayTime = TextBox_PlayTime.Text;

            switch (((MediaData)listObjects.SelectedItem).typeData)
            {
                case Enums.TypeMediaFile.Track: MediaData = (Music)listObjects.SelectedItem; break;
                case Enums.TypeMediaFile.Folder: MediaData = (Folder)listObjects.SelectedItem; break;
            }
        }

        private void Cancel_Click(object sender, RoutedEventArgs e)
        {
            DialogResult = false;
        }

        private void PrioritySelect_Clicked(object sender, RoutedEventArgs e)
        {
            if (PrioritySelect.IsChecked == true)
            {
                List<Folder> tmpFolders = new List<Folder>()
                    {
                        folderLists.Folder5Min,
                        folderLists.Folder10Min,
                        folderLists.Folder40Min
                    };

                listObjects.DisplayMemberPath = "Name";
                listObjects.ItemsSource = tmpFolders;
            }
            else
            {
                List<List<Music>> trackLists = new List<List<Music>>()
                    {
                        musicLists.Min5,
                        musicLists.Min10,
                        musicLists.Min40
                    };
                List<Music> tmpTracks = new List<Music>();

                foreach (List<Music> list in trackLists)
                {
                    foreach (Music track in list)
                    {
                        tmpTracks.Add(track);
                    }
                }

                listObjects.DisplayMemberPath = "Path";
                listObjects.ItemsSource = tmpTracks;
            }
        }
    }
}
