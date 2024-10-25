using System;

namespace Belly.Classes.StaticClasses
{
    public class SettingsValues
    {
        private float _basicVolume;
        public float basicVolume 
        {
            get 
            {
                return (float)Math.Round(_basicVolume, 2);
            }
            set
            {
                _basicVolume = value;
            } 
        }
        private float _middleVolume;
        public float middleVolume
        {
            get
            {
                return (float)Math.Round(_middleVolume, 2);
            }
            set
            {
                _middleVolume = value;
            }
        }
        private float _introOutroVolume;
        public float introOutroVolume 
        {
            get
            {
                return (float)Math.Round(_introOutroVolume, 2);
            }
            set
            {
                _introOutroVolume = value;
            } 
        }

        public int durationIntroOutroVolume { get; set; }
        public int durationTransitionToMiddleVolume { get; set; }
        public int durationTransitionToUpVolume { get; set; }
        public int durationTransitionToEndVolume { get; set; }
    }
}
