using Belly.Enums;
using System.Runtime.CompilerServices;
using System.Windows;

namespace Belly.Objects
{
    public class Track : MediaData
    {
        public Track(string path) : base(TypeData.Track)
        {
            Path = path;
            priority = 1;
        }

        private int priority { get; set; }

        
        public string Name 
        { 
            get 
            {
                return System.IO.Path.GetFileName(Path);
            } 
        }
        public string Path { get; }
        public int Priority
        {
            set
            {
                if (value >= 1) priority = value;
                else MessageBox.Show("Нельзя указывать приоритет ниже 1.", "Указано значение ниже 1", MessageBoxButton.OK, MessageBoxImage.Warning);
            }
            get
            {
                return priority;
            }
        }
    }
}
