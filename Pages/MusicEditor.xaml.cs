﻿using Belly.Objects;
using Newtonsoft.Json;
using System.IO;
using System.Windows.Controls;
using System.Windows.Forms;

namespace Belly.Pages
{
    public partial class MusicEditor : Page
    {
        public MusicEditor()
        {
            InitializeComponent();
            InitializeData();
        }
        void InitializeData()
        {
            DataGrid_MusicList.ItemsSource = Main.MusicList;
            DataGrid_AudioList.ItemsSource = Main.AudioList;
        }
        private void DataGrid_Drop(object sender, System.Windows.DragEventArgs e)
        {
            if (e.Data.GetDataPresent(DataFormats.FileDrop))
            {
                string[] files = (string[])e.Data.GetData(DataFormats.FileDrop);


                foreach (string file in files)
                {
                    if (System.IO.Path.GetExtension(file).ToLower() == ".mp3")
                    {
                        switch (((DataGrid)sender).Tag)
                        {
                            case "Music":

                                if (!Main.MusicList.Exists(f => f.Name == Path.GetFileName(file)))
                                {
                                    Music music = new Music(file);

                                    Main.MusicList.Add(music);
                                    File.Copy(file, $@"Music\{music.Name}", true);

                                    DataGrid_MusicList.Items.Refresh();

                                    var json = JsonConvert.SerializeObject(Main.MusicList, Formatting.Indented);
                                    File.WriteAllText(@"Music\listInfo.json", json);
                                }
                                break;
                            case "Audio":
                                if (!Main.AudioList.Exists(f => f.Name == Path.GetFileName(file)))
                                {
                                    Audio audio = new Audio(file);

                                    Main.AudioList.Add(audio);
                                    File.Copy(file, $@"Audio\{audio.Name}", true);

                                    DataGrid_AudioList.Items.Refresh();
                                }
                                break;
                        }

                    }
                }
            }
        }

        private void Delete_Click(object sender, System.Windows.RoutedEventArgs e)
        {
            foreach (Audio item in DataGrid_AudioList.SelectedItems)
            {
                Main.AudioList.Remove(item);
                File.Delete(item.Path);
            }
            foreach (Music item in DataGrid_MusicList.SelectedItems)
            {
                Main.MusicList.Remove(item);
                File.Delete(item.Path);
            }
            var json = JsonConvert.SerializeObject(Main.MusicList, Formatting.Indented);
            File.WriteAllText(@"Music\listInfo.json", json);

            DataGrid_AudioList.Items.Refresh();
            DataGrid_MusicList.Items.Refresh();

            button_deleteIssue.IsEnabled = false;
            button_unselect.IsEnabled = false;

        }

        private void ClearSelect_Click(object sender, System.Windows.RoutedEventArgs e)
        {
            DataGrid_MusicList.SelectedItem = null;
            DataGrid_AudioList.SelectedItem = null;

            button_deleteIssue.IsEnabled = false;
            button_unselect.IsEnabled = false;
        }

        private void DataGrid_MusicList_CellEditEnding(object sender, DataGridCellEditEndingEventArgs e)
        {
            var json = JsonConvert.SerializeObject(Main.MusicList, Formatting.Indented);
            File.WriteAllText(@"Music\listInfo.json", json);
        }

        private void DataGrid_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (DataGrid_MusicList.SelectedItems.Count > 0 || DataGrid_AudioList.SelectedItems.Count > 0)
            {
                button_unselect.IsEnabled = true;
                button_deleteIssue.IsEnabled = true;
            }
            else if (DataGrid_MusicList.SelectedItems.Count < 0 || DataGrid_AudioList.SelectedItems.Count < 0)
            {
                button_deleteIssue.IsEnabled = false;
                button_unselect.IsEnabled = false;
            }
        }
    }
}
