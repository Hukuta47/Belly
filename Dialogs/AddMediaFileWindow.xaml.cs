using System.Windows;

namespace Belly.Dialogs
{
    public partial class AddMediaFileWindow : Window
    {
        public bool SelectedMusic, SelectedAudio;
        public AddMediaFileWindow()
        {
            InitializeComponent();
        }
        private void Cancel_Click(object sender, RoutedEventArgs e)
        {
            DialogResult = false;
        }

        private void Radio_SelectedMusic_Click(object sender, RoutedEventArgs e)
        {
            SelectedMusic = true;
            SelectedAudio = false;
        }
        private void Radio_SelectedAudio_Click(object sender, RoutedEventArgs e)
        {
            SelectedMusic = false;
            SelectedAudio = true;
        }
        private void Accept_Click(object sender, RoutedEventArgs e)
        {
            DialogResult = true;
        }
    }
}
