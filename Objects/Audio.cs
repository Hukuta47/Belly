using Belly.Enums;

namespace Belly.Objects
{
    public class Audio : MediaFile
    {
        new string Path { get; }
        new public string Name
        {
            get
            {
                return System.IO.Path.GetFileName(Path);
            }
        }

        public Audio(string Path) : base(Path, TypeMediaFile.Audio)
        {
            this.Path = Path;
        }
    }
}
