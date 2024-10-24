using Belly.Enums;

namespace Belly.Objects
{
    public class MediaFile
    {
        TagLib.File _fileInfo;

        public string Duration 
        { 
            get
            {
                int hours = _fileInfo.Properties.Duration.Hours;
                int minutes = _fileInfo.Properties.Duration.Minutes;
                int seconds = _fileInfo.Properties.Duration.Seconds;

                if (hours == 0)
                {
                    return $"{minutes}:{seconds}";
                }
                else
                {
                    return $"{hours}:{minutes}:{seconds}";
                }
            }
        }
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
            _fileInfo = TagLib.File.Create(Path);
        }
    }
}
