using Belly.Classes.StaticClasses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Belly.Classes
{
    public class ProgramObjects
    {
        public static MainWindow Main;

        ProgramObjects(MainWindow main) 
        { 
            Main = main;
        }
        public SettingsValues SettingsValues { get; set; }
        public Player Player { get; set; }
    }
}
