using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using Belly.Objects;
using Newtonsoft.Json;


namespace Belly.Classes.StaticClasses
{
    public class musicLists
    {
        static public List<Track> Folder5Min = new List<Track>();
        static public List<Track> Folder10Min = new List<Track>();
        static public List<Track> Folder40Min = new List<Track>();

        static List<string> Folders = new List<string>() 
        {
            "5 min",
            "10 min",
            "40 min"

        };
        static public void RefreshLists()
        {
            foreach (string folderPath in Folders)
            {

            }
            
        }


        
    }
}
