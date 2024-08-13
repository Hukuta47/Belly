using Belly.Enums;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Belly.Objects
{
    public class Folder : MediaData
    {
        public Folder(string name) : base(TypeData.Folder)
        {
            Name = name;
        }

        public string GetPriorityPath(List<Track> listTracks)
        {
            List<Tuple<string, int>> items = new List<Tuple<string, int>>();

            foreach (Track track in listTracks)
            {
                items.Add(new Tuple<string, int>(track.Path, track.Priority));
            }


            int totalWeight = items.Sum(item => item.Item2);
            Random rand = new Random();
            int randomValue = rand.Next(totalWeight);

            foreach (var item in items)
            {
                if (randomValue < item.Item2)
                {
                    return item.Item1;
                }
                randomValue -= item.Item2;
            }

            return "None";
        }

    }
}
