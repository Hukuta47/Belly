using Belly.Objects;
using System.Windows;


namespace Belly.Dialogs
{
    public partial class AddScheduleWindow : Window
    {
        public string Name;
        public string PlayTime;
        public MediaData MediaData;
        public AddScheduleWindow()
        {
            InitializeComponent();

            Name = TextBox_Name.Text;
            PlayTime = TextBox_PlayTime.Text;

        }

        private void Create_Click(object sender, RoutedEventArgs e)
        {
            DialogResult = true;
        }

        private void Cancel_Click(object sender, RoutedEventArgs e)
        {

        }
    }
}
