using System;

namespace Belly.Objects
{
    public class Bell
    {
        public Bell(string Name, DateTime StartTime, DateTime EndTime, MediaFile Media) 
        {
            this.Name = Name;
            this.StartTime = StartTime;
            this.EndTime = EndTime;
            this.Media = Media;
        }
        public Bell(string Name, DateTime StartTime, MediaFile Media)
        {
            this.Name = Name;
            this.StartTime = StartTime;
            this.Media = Media;
        }

        public string Name { get; set; }
        public DateTime StartTime { get; set; }
        public DateTime? EndTime { get; set; }
        public bool volumeUpDown { get; set; } = false;
        public MediaFile Media { get; set; }
    }
}
