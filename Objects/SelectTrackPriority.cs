using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Shapes;

namespace Belly.Objects
{
    public class SelectTrackPriority : Track
    {
        List<Track> Playlist = new List<Track>();


        public SelectTrackPriority(List<Track> tracks) : base(path:"")
        {
            foreach(Track track in tracks)
            {
                Playlist.Add(track);
            }
        }

        public string Name
        {
            get
            {
                return $"По приотету из {System.IO.Path.GetDirectoryName(Path)}";
            }
        }
        public string Path 
        {
            get
            {
                return GetPriorityPath(Playlist); 
            }
        }

        string GetPriorityPath(List<Track> playlist)
        {
            List<Tuple<string, int>> items = new List<Tuple<string, int>>();
            
            foreach (Track track in playlist)
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
