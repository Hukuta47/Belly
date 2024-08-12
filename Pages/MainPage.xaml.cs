using Belly.Classes.StaticClasses;
using Belly.Objects;
using NAudio.Wave;
using System.Windows;
using System.Windows.Controls;

namespace Belly.Pages
{
    public partial class MainPage : Page
    {
        public MainPage()
        {
            InitializeComponent();

            cmbx.ItemsSource = sheduleList.basicSchedule.bells;

        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            string pathToTrack = "";

            switch (((Bell)cmbx.SelectedItem).Media.typeData)
            {
                case Enums.TypeData.Track:
                    Bell tmp = (Bell)cmbx.SelectedItem;

                    MessageBox.Show(tmp.Media.Name);

                    pathToTrack = ((Track)((Bell)cmbx.SelectedItem).Media).Path;
                    break;
                case Enums.TypeData.Folder:
                    pathToTrack = ((Folder)((Bell)cmbx.SelectedItem).Media).GetPriorityPath(musicLists.Min5);
                    break;
            }


            var audioFile = new AudioFileReader(pathToTrack);
            var outputDevice = new WaveOutEvent();


            outputDevice.Init(audioFile);
            outputDevice.Play();
        }
    }
}
