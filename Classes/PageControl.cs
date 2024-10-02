using Belly.Pages;

using System.Windows.Controls;

namespace Belly.Classes
{
    public class PageControl
    {
        Page musicEditor = new MusicEditor();
        Page sheduleEditor = new SheduleEditor();
        Page mainPage = new MainPage();
        Page settings = new Settings();

        Frame mainFrame;

        public enum Pages
        {
            musicEditor,
            sheduleEditor,
            mainPage,
            settings
        }
        public PageControl(Frame frame)
        {
            mainFrame = frame;
        }
        public void ChangePage(Pages pages)
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
