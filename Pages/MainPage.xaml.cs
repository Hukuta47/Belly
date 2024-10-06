using System.Windows.Controls;

namespace Belly.Pages
{

    public partial class MainPage : Page
    {
        public static Label timeText;
        public MainPage()
        {
            InitializeComponent();
            timeText = TimeLabel;
            TimeLabel.Content = MainWindow.TimeNow.ToString();

        }

    }
}
 