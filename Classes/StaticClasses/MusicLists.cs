using System.Collections.Generic;
using System.IO;
using Belly.Objects;


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
                foreach (string path in Directory.GetFiles(folderPath, "*.mp3"))
                {
                    switch (folderPath)
                    {
                        case "5 min":
                            Folder5Min.Add(new Belly.Objects.Track(path));
                            break;
                        case "10 min":
                            Folder10Min.Add(new Belly.Objects.Track(path));
                            break;
                        case "40 min":
                            Folder40Min.Add(new Belly.Objects.Track(path));
                            break;
                    }
                }
            }
            
        }
    }
}
