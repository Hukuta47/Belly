
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
        }
        private void Button_Click(object sender, RoutedEventArgs e)
        {

        }
        private void SaveClick(object sender, RoutedEventArgs e)
        {

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
                            File.Copy(file, $"5 min\\{Path.GetFileName(file)}", true);
                            musicLists.Folder5Min.Add(new Track($"5min\\{file}"));
                            musicLists.Folder5Min = RemoveDuplicates(musicLists.Folder5Min);


                            var json = JsonConvert.DeserializeObject<List<Track>>(File.ReadAllText("5 min\\listInfo.json"));
                            json = RemoveDuplicates(json);
                            json.Add(new Track($"5 min\\{file}"));
                            // TODO: sort
                            var jsonWrit = JsonConvert.SerializeObject(json, Formatting.Indented);
                            File.WriteAllText("5 min\\listInfo.json", jsonWrit);
                        }
                        if (addTrackWindow.Accept10min)
                        {
                            File.Copy(file, $"10 min\\{Path.GetFileName(file)}", true);
                            musicLists.Folder10Min.Add(new Track($"5min\\{file}"));
                            musicLists.Folder10Min = RemoveDuplicates(musicLists.Folder10Min);

                            var json = JsonConvert.DeserializeObject<List<Track>>(File.ReadAllText("5 min\\listInfo.json"));
                            json = RemoveDuplicates(json);
                            json.Add(new Track($"10 min\\{file}"));
                            // TODO: sort
                            var jsonWrit = JsonConvert.SerializeObject(json, Formatting.Indented);
                            File.WriteAllText("10 min\\listInfo.json", jsonWrit);
                        }
                        if (addTrackWindow.Accept40min)
                        {
                            File.Copy(file, $"40 min\\{Path.GetFileName(file)}", true);
                            musicLists.Folder40Min.Add(new Track($"5min\\{file}"));
                            musicLists.Folder40Min = RemoveDuplicates(musicLists.Folder40Min);

                            var json = JsonConvert.DeserializeObject<List<Track>>(File.ReadAllText("5 min\\listInfo.json"));
                            json = RemoveDuplicates(json);
                            json.Add(new Track($"40 min\\{file}"));
                            // TODO: sort
                            var jsonWrit = JsonConvert.SerializeObject(json, Formatting.Indented);
                            File.WriteAllText("40 min\\listInfo.json", jsonWrit);
                        }
                    }
                }
            }

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
