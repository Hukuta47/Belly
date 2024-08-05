

using System.IO;

namespace Belly.Objects
{
    public class Track
    {
        public Track(string path)
        {
            Path = path;
            Priority = 0;
        }
        public string Name 
        { 
            get 
            {
                return System.IO.Path.GetFileName(Path);
            } 
        }
        public string Path { get; }
        public int Priority { get; set; }
    }
}
