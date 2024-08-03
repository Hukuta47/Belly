using Belly.Pages;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace Belly.Classes
{
    public class PageControl
    {
        static Page musicEditor = new MusicEditor();

        static public Frame mainFrame;

        public enum Pages
        {
            musicEditor
        }


        static public void ChangePage(Pages pages)
        {
            switch (pages)
            {
                case Pages.musicEditor:
                    mainFrame.Navigate(musicEditor);
                    break;
            }
        }
    }
}
