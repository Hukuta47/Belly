using Belly.Enums;

namespace Belly.Objects
{
    public class Audio : MediaFile
    {
        public new string Path { get; }
        new public string Name
        {
            get
            {
                return System.IO.Path.GetFileName(Path);
            }
        }

        public Audio(string Path) : base(Path, TypeMediaFile.Audio)
        {
            string _name = System.IO.Path.GetFileName(Path);
            this.Path = $@"Audio\{_name}";
        }
    }
}
