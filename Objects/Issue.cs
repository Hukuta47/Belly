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
        public IssueType IssueType { get; set; }
        public string Name { get; set; }
        public TimeOnly StartTime { get; set; }
        public TimeOnly? EndTime { get; set; }
        private int PlayTime
        {
            get
            {

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

        public async void Start()
        {
            await StartPlay();
        }
        async Task StartPlay()
        {
            switch (IssueType)
            {
                case IssueType.Music:
                    await Task.Delay(1);
                break;
                case IssueType.Audio:
                    await MainWindow.Player.Play(MediaFile.Path, VolumeUpDown);
                break;
            }
            
            //stop
        }


    }
}
