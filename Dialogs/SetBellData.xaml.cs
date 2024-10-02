using Belly.Classes.StaticClasses;
using Belly.Enums;
using Belly.Objects;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.Windows;


namespace Belly.Dialogs
{
    public partial class SetBellData : Window
    {
        public Bell SelectedItem;
        public SetBellData(object selectedItem)
        {
            InitializeComponent();


            SelectedItem = (Bell)selectedItem;

            var objType = SelectedItem.Media;




            TextBox_Name.Text = SelectedItem.Name;
            TextBox_PlayTime.Text = SelectedItem.PlayTime;

            switch (objType.typeData)
            {
                case TypeMediaFile.Track:

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

                    break;

                case TypeMediaFile.Folder:

                    List<Folder> tmpFolders = new List<Folder>()
                    {
                        folderLists.Folder5Min,
                        folderLists.Folder10Min,
                        folderLists.Folder40Min
                    };

                    listObjects.DisplayMemberPath = "Name";
                    listObjects.ItemsSource = tmpFolders;


                    break;
            }

        }

        private void SaveClick(object sender, RoutedEventArgs e)
        {
            DialogResult = true;

            SelectedItem.Name = TextBox_Name.Text;
            SelectedItem.PlayTime = TextBox_PlayTime.Text;

            SelectedItem.Media = (MediaData)listObjects.SelectedItem;

        }

        private void CancelClick(object sender, RoutedEventArgs e)
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
