using Belly.Enums;
using System;

namespace Belly.Objects
{
    public class Issue
    {
        public Issue(string Name, TimeOnly StartTime, TimeOnly EndTime, bool VolumeUpDown) 
        {
            issueType = IssueType.Music;
            this.Name = Name;
            this.StartTime = StartTime;
            this.EndTime = EndTime;
            this.VolumeUpDown = VolumeUpDown;
            
        }
        public Issue(string Name, TimeOnly StartTime, MediaFile Media)
        {
            issueType = IssueType.Audio;
            this.Name = Name;
            this.StartTime = StartTime;
            this.Media = Media;
        }
        public IssueType issueType { get; set; }
        public string Name { get; set; }
        public TimeOnly StartTime { get; set; }
        public TimeOnly? EndTime { get; set; }
        public bool? VolumeUpDown { get; set; }
        public MediaFile Media { get; set; }

        public string text_StartTime
        { 
            get
            {
                return StartTime.ToString();
            } 
        }
        public string text_EndTime
        {
            get
            {
                return EndTime.ToString();
            }
        }
    }
}
