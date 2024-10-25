using Belly.Pages;

using System.Windows.Controls;

namespace Belly.Classes
{
    public class PageControl
    {
        MusicEditor musicEditor = new MusicEditor();
        public MainPage mainPage = new MainPage();
        SheduleEditor sheduleEditor = new SheduleEditor();
        Settings settings = new Settings();

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
