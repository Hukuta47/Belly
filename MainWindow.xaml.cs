using Belly.Classes;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;


namespace Belly
{

    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            PageControl.mainFrame = frame;
            InitializeFolders();
        }
        void InitializeFolders()
        {
            List<string> list = new List<string>()
            {
                "5 min",
                "10 min",
                "40 min"
            };
            foreach (string folder in list)
            {
                if (!Directory.Exists(folder))
                {
                    Directory.CreateDirectory(folder);
                    File.WriteAllText($"{folder}\\listInfo.json", "[]");
                }
            }
        }




        private void Button_Click(object sender, RoutedEventArgs e)
        {
            Button button = (Button)sender;


            switch (button.Tag)
            {
                case "music":
                    PageControl.ChangePage(PageControl.Pages.musicEditor);
                    break;
            }
        }
    }
}
