using Belly.Classes.StaticClasses;
using Belly.Dialogs;
using Belly.Objects;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Windows;
using System.Windows.Controls;

namespace Belly.Pages
{
    public partial class MusicEditor : Page
    {
        public MusicEditor()
        {
            InitializeComponent();
            LoadTracks();
        }
        private void DeleteClick(object sender, RoutedEventArgs e)
        {
            List<DataGrid> dataGrids = new List<DataGrid>()
            {
                DataGrid5Min,
                DataGrid10Min,
                DataGrid40Min
            };

            foreach (DataGrid dataGrid in dataGrids)
            {
                List<Track> tempTracks = dataGrid.ItemsSource as List<Track>;

                foreach (Track selectTrack in dataGrid.SelectedItems)
                {
                    tempTracks.Remove(selectTrack);
                }
                dataGrid.ItemsSource = null;
                dataGrid.ItemsSource = tempTracks;


            }
            SaveClick();
        }
        private void SaveClick(object sender, RoutedEventArgs e)
        {
            var json1 = JsonConvert.SerializeObject(DataGrid5Min.ItemsSource, Formatting.Indented);
            var json2 = JsonConvert.SerializeObject(DataGrid10Min.ItemsSource, Formatting.Indented);
            var json3 = JsonConvert.SerializeObject(DataGrid40Min.ItemsSource, Formatting.Indented);

            File.WriteAllText("5 min\\listInfo.json", json1);
            File.WriteAllText("10 min\\listInfo.json", json2);
            File.WriteAllText("40 min\\listInfo.json", json3);
        }
        private void SaveClick()
        {
            var json1 = JsonConvert.SerializeObject(DataGrid5Min.ItemsSource, Formatting.Indented);
            var json2 = JsonConvert.SerializeObject(DataGrid10Min.ItemsSource, Formatting.Indented);
            var json3 = JsonConvert.SerializeObject(DataGrid40Min.ItemsSource, Formatting.Indented);

            File.WriteAllText("5 min\\listInfo.json", json1);
            File.WriteAllText("10 min\\listInfo.json", json2);
            File.WriteAllText("40 min\\listInfo.json", json3);
        }
        void LoadTracks()
        {
            DataGrid5Min.ItemsSource = JsonConvert.DeserializeObject<List<Track>>(File.ReadAllText("5 min\\listInfo.json"));
            DataGrid10Min.ItemsSource = JsonConvert.DeserializeObject<List<Track>>(File.ReadAllText("10 min\\listInfo.json"));
            DataGrid40Min.ItemsSource = JsonConvert.DeserializeObject<List<Track>>(File.ReadAllText("40 min\\listInfo.json"));
        }
        private void Page_Drop(object sender, DragEventArgs e)
        {
            string[] files = (string[])e.Data.GetData(DataFormats.FileDrop);
            AddTrackWindow addTrackWindow = new AddTrackWindow();
            
            if (addTrackWindow.ShowDialog() == true)
            {
                foreach (string file in files)
                {
                    if (Path.GetExtension(file).Equals(".mp3", StringComparison.OrdinalIgnoreCase))
                    {
                        if (addTrackWindow.Accept5min)
                        {
                            File.Copy(file, $"5 min\\{Path.GetFileName(file)}", false);
                            musicLists.Folder5Min.Add(new Track($"5min\\{Path.GetFileName(file)}"));
                            musicLists.Folder5Min = RemoveDuplicates(musicLists.Folder5Min);


                            var json = JsonConvert.DeserializeObject<List<Track>>(File.ReadAllText("5 min\\listInfo.json"));
                            json = RemoveDuplicates(json);
                            json.Add(new Track($"5 min\\{Path.GetFileName(file)}"));
                            json.Sort((m1, m2) => string.Compare(m1.Name, m2.Name, StringComparison.Ordinal)); // Сортировка А-Я
                            var jsonWrit = JsonConvert.SerializeObject(json, Formatting.Indented);
                            File.WriteAllText("5 min\\listInfo.json", jsonWrit);
                        }
                        if (addTrackWindow.Accept10min)
                        {
                            File.Copy(file, $"10 min\\{Path.GetFileName(file)}", false);
                            musicLists.Folder10Min.Add(new Track($"5min\\{Path.GetFileName(file)}"));
                            musicLists.Folder10Min = RemoveDuplicates(musicLists.Folder10Min);

                            var json = JsonConvert.DeserializeObject<List<Track>>(File.ReadAllText("5 min\\listInfo.json"));
                            json = RemoveDuplicates(json);
                            json.Add(new Track($"10 min\\{Path.GetFileName(file)}"));
                            json.Sort((m1, m2) => string.Compare(m1.Name, m2.Name, StringComparison.Ordinal)); // Сортировка А-Я
                            var jsonWrit = JsonConvert.SerializeObject(json, Formatting.Indented);
                            File.WriteAllText("10 min\\listInfo.json", jsonWrit);
                        }
                        if (addTrackWindow.Accept40min)
                        {
                            File.Copy(file, $"40 min\\{Path.GetFileName(file)}", false);
                            musicLists.Folder40Min.Add(new Track($"5min\\{Path.GetFileName(file)}"));
                            musicLists.Folder40Min = RemoveDuplicates(musicLists.Folder40Min);

                            var json = JsonConvert.DeserializeObject<List<Track>>(File.ReadAllText("5 min\\listInfo.json"));
                            json = RemoveDuplicates(json);
                            json.Add(new Track($"40 min\\{Path.GetFileName(file)}"));
                            json.Sort((m1, m2) => string.Compare(m1.Name, m2.Name, StringComparison.Ordinal)); // Сортировка А-Я
                            var jsonWrit = JsonConvert.SerializeObject(json, Formatting.Indented);
                            File.WriteAllText("40 min\\listInfo.json", jsonWrit);
                        }
                    }
                }
            }

            musicLists.Folder5Min.Sort((m1, m2) => string.Compare(m1.Name, m2.Name, StringComparison.Ordinal)); // Сортировка А-Я
            musicLists.Folder10Min.Sort((m1, m2) => string.Compare(m1.Name, m2.Name, StringComparison.Ordinal)); // Сортировка А-Я
            musicLists.Folder40Min.Sort((m1, m2) => string.Compare(m1.Name, m2.Name, StringComparison.Ordinal)); // Сортировка А-Я

            DataGrid5Min.ItemsSource = musicLists.Folder5Min;
            DataGrid10Min.ItemsSource = musicLists.Folder10Min;
            DataGrid40Min.ItemsSource = musicLists.Folder40Min;

        }

        public static List<T> RemoveDuplicates<T>(List<T> list)
        {
            HashSet<T> seenElements = new HashSet<T>();
            List<T> uniqueList = new List<T>();

            foreach (T item in list)
            {
                if (seenElements.Add(item))
                {
                    uniqueList.Add(item);
                }
            }

            return uniqueList;
        }

    }
}
