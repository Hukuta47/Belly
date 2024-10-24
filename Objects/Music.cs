using System.IO;
using System.Windows;
using Belly.Enums;
using System.Windows.Shapes;

namespace Belly.Objects
{
    public class Music : MediaFile
    {
        
        public Music(string Path) : base(Path, TypeMediaFile.Track)
        {
            string _name = System.IO.Path.GetFileName(Path);
            this.Path = $@"Music\{_name}";
            priority = 1;
        }
        private int priority { get; set; }
        new public string Name 
        { 
            get 
            {
                return System.IO.Path.GetFileName(Path);
            } 
        }
        new public string Path { get; }
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
