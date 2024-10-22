using Belly.Objects;
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
    }
}
