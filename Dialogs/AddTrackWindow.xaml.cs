using System.Windows;

namespace Belly.Dialogs
{
    public partial class AddTrackWindow : Window
    {
        public bool Accept5min, Accept10min, Accept40min;
        public AddTrackWindow()
        {
            InitializeComponent();
        }
        private void Cancel_Click(object sender, RoutedEventArgs e)
        {
            DialogResult = false;
        }

        private void Accept_Click(object sender, RoutedEventArgs e)
        {
            Accept5min = Checkbox5min.IsChecked.Value;
            Accept10min = Checkbox10min.IsChecked.Value;
            Accept40min = Checkbox40min.IsChecked.Value;
            DialogResult = true;
        }
    }
}
