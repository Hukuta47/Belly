using Belly.Enums;
using System;
using System.Threading.Tasks;

namespace Belly.Objects
{
    public class Issue
    {
        public Issue() {}
        public Issue(string Name, TimeOnly StartTime, TimeOnly EndTime, bool VolumeUpDown) 
        {
            IssueType = IssueType.Music;
            this.Name = Name;
            this.StartTime = StartTime;
            this.EndTime = EndTime;
            this.VolumeUpDown = VolumeUpDown;
            
        }
        public Issue(string Name, TimeOnly StartTime, MediaFile MediaFile)
        {
            IssueType = IssueType.Audio;
            this.Name = Name;
            this.StartTime = StartTime;
            this.MediaFile = MediaFile;
        }
        public async void Start()
        {
            switch (IssueType)
            {
                case IssueType.Music:

                    break;
                case IssueType.Audio:

                    break;
            }
        }
        public IssueType IssueType { get; set; }
        public string Name { get; set; }
        public TimeOnly StartTime { get; set; }
        public TimeOnly? EndTime { get; set; }
        private int PlayTime
        {
            get
            {
                return EndTime.Value.Millisecond - StartTime.Millisecond;
            }
        }
        public bool? VolumeUpDown { get; set; }
        public MediaFile MediaFile { get; set; }
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
