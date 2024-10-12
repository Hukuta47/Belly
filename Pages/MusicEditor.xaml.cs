using Belly.Objects;
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
            DataGrid_MusicList.ItemsSource = MainWindow.MusicList;
            DataGrid_AudioList.ItemsSource = MainWindow.AudioList;
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
                                MainWindow.MusicList.Add(new Music(file));
                                DataGrid_MusicList.Items.Refresh();
                            break;
                            case "Audio": 
                                Audio audio = new Audio(file);
                                MainWindow.AudioList.Add(audio);
                                File.Copy(file, $@"Audio\{audio.Name}");
                                DataGrid_AudioList.Items.Refresh();
                            break;
                        }

                    }
                }
            }

        }
    }
}
