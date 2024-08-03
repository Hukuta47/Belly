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
        Page musicEditor = new MusicEditor();

        static Frame mainFrame;

        public enum Pages
        {
            musicEditor
        }


        static void ChangePage()
        {

        }
    }
}
