﻿using System;

namespace Belly.Objects
{
    public class Bell
    {
        public Bell(string Name, TimeOnly StartTime, TimeOnly EndTime, MediaFile Media) 
        {
            this.Name = Name;
            this.StartTime = StartTime;
            this.EndTime = EndTime;
            this.Media = Media;


            new TimeOnly();
        }
        public Bell(string Name, TimeOnly StartTime, MediaFile Media)
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
