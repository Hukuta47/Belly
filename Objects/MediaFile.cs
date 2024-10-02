using Belly.Enums;

namespace Belly.Objects
{
    public class MediaFile
    {
        public string Name
        {
            get
            {
                return System.IO.Path.GetFileName(Path);
            }
        }
        public string Path { get; }
        public TypeMediaFile Type { get; }
        public MediaFile(string Path, TypeMediaFile Type)
        {
            this.Path = Path;
            this.Type = Type;
        }
    }
}
