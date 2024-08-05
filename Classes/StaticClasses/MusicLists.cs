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
        //listInfo.json

        static public void RefreshLists()
        {
            List<string> Folders = new List<string>()
            {
                "5 min",
                "10 min",
                "40 min"
            };
            foreach (string folderPath in Folders)
            {
                switch (folderPath)
                {
                    case "5 min":
                        break;
                    case "10 min":
                        break;
                    case "40 min":
                        break;
                }
            }
            
        }
        static public void SaveLists(params List<Track>[] listTracks)
        {
            List<string> Folders = new List<string>()
            {
                "5 min",
                "10 min",
                "40 min"
            };
            foreach(string folderPath in Folders)
            {
                switch (folderPath)
                {
                    case "5 min":
                        var firstJson = JsonConvert.SerializeObject(listTracks[0], Formatting.Indented);
                        File.WriteAllText(folderPath + "\\listInfo.json", firstJson);
                        break;
                    case "10 min":
                        var secondJson = JsonConvert.SerializeObject(listTracks[1], Formatting.Indented);
                        File.WriteAllText(folderPath + "\\listInfo.json", secondJson);
                        break;
                    case "40 min":
                        var thirdJson = JsonConvert.SerializeObject(listTracks[2], Formatting.Indented);
                        File.WriteAllText(folderPath + "\\listInfo.json", thirdJson);
                        break;
                }
            }


        }
        static public void LoadLists()
        {
            List<string> Folders = new List<string>()
            {
                "5 min",
                "10 min",
                "40 min"
            };
            foreach (string folderPath in Folders)
            {
                switch (folderPath)
                {
                    case "5 Min":
                        break;
                    case "10 Min":
                        break;
                    case "40 Min":
                        break;
                }
            }

        }


    }
}
