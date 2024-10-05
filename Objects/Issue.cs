using System;

namespace Belly.Objects
{
    public class Issue
    {
        public Issue(string Name, TimeOnly StartTime, TimeOnly EndTime, MediaFile Media) 
        {
            this.Name = Name;
            this.StartTime = StartTime;
            this.EndTime = EndTime;
            this.Media = Media;
        }
        public Issue(string Name, TimeOnly StartTime, TimeOnly? endTime, MediaFile Media)
        {
            this.Name = Name;
            this.StartTime = StartTime;
            this.Media = Media;
        }

        public string Name { get; set; }
        public TimeOnly StartTime { get; set; }
        public TimeOnly? EndTime { get; set; }
        public bool volumeUpDown { get; set; } = false;
        public MediaFile Media { get; set; }
    }
}
