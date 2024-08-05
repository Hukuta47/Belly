using Belly.Classes;
using Belly.Classes.StaticClasses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

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
            musicLists.RefreshLists();

            DataGrid5Min.ItemsSource = musicLists.Folder5Min;
            DataGrid10Min.ItemsSource = musicLists.Folder10Min;
            DataGrid40Min.ItemsSource = musicLists.Folder40Min;
        }
    }
}
