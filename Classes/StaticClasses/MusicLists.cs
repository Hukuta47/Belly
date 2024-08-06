using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Windows;
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
            foreach (var folder in Folders)
            {
                var listMusic = JsonConvert.DeserializeObject<List<Track>>(File.ReadAllText(folder + "\\listInfo.json"));
                var listFiles = Directory.GetFiles(folder, "*.mp3").ToList();

                List<Track> lsitToDelete = new List<Track>();


                foreach (var track in listMusic) // Проверка на существование файлов
                {
                    if (listMusic.Exists(l => l.Path == track.Path))
                    {
                        lsitToDelete.Add(track);
                    }
                }

                foreach (string pathFile in Directory.GetFiles(folder, "*.mp3"))
                {
                    if (!listMusic.Exists(l => l.Path == pathFile))
                    {
                        listMusic.Add(new Track(pathFile));
                    }
                }

                

                foreach (Track track in lsitToDelete) // Удаление не смущестующих файлов
                {
                    listMusic.Remove(track);
                }



                var writeJson = JsonConvert.SerializeObject(listMusic, Formatting.Indented);
                File.WriteAllText(folder + "\\listInfo.json", writeJson);

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
                        listTracks[0].Sort((m1, m2) => string.Compare(m1.Name, m2.Name, StringComparison.Ordinal));
                        var firstJson = JsonConvert.SerializeObject(listTracks[0], Formatting.Indented);
                        File.WriteAllText(folderPath + "\\listInfo.json", firstJson);
                        break;
                    case "10 min":
                        listTracks[1].Sort((m1, m2) => string.Compare(m1.Name, m2.Name, StringComparison.Ordinal));
                        var secondJson = JsonConvert.SerializeObject(listTracks[1], Formatting.Indented);
                        File.WriteAllText(folderPath + "\\listInfo.json", secondJson);
                        break;
                    case "40 min":
                        listTracks[2].Sort((m1, m2) => string.Compare(m1.Name, m2.Name, StringComparison.Ordinal));
                        var thirdJson = JsonConvert.SerializeObject(listTracks[2], Formatting.Indented);
                        File.WriteAllText(folderPath + "\\listInfo.json", thirdJson);
                        break;
                }
            }


        }
        static public List<Track> LoadList(string filePath)
        {
            List<Track> json = JsonConvert.DeserializeObject<List<Track>>(File.ReadAllText(filePath));

            return json;
        }

        //jsonList.Sort((m1, m2) => string.Compare(m1.Name, m2.Name, StringComparison.Ordinal)); // Сортировка А-Я
    }
}
