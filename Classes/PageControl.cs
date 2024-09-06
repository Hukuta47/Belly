using Belly.Pages;

using System.Windows.Controls;

namespace Belly.Classes
{
    public class PageControl
    {
        static Page musicEditor = new MusicEditor();
        static Page sheduleEditor = new SheduleEditor();
        static Page mainPage = new MainPage();
        static Page settings = new Settings();

        static public Frame mainFrame;

        public enum Pages
        {
            musicEditor,
            sheduleEditor,
            mainPage,
            settings
        }


        static public void ChangePage(Pages pages)
        {
            switch (pages)
            {
                case Pages.musicEditor:
                    mainFrame.Navigate(musicEditor);
                    break;
                case Pages.sheduleEditor:
                    mainFrame.Navigate(sheduleEditor);
                    break;
                case Pages.mainPage:
                    mainFrame.Navigate(mainPage);
                    break;
                case Pages.settings:
                    mainFrame.Navigate(settings);
                    break;
            }
        }
    }
}
