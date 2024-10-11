
using System.Threading.Tasks;
using Belly.Objects;
using Belly;
using NAudio.Wave;
using System.Windows.Documents;
using System.Collections.Generic;
using System.Linq;
using System;
using System.Data;

namespace Belly.Classes.StaticClasses
{
    public class Player
    {

        public SettingsValues _settings;

        public WaveOutEvent OutputDevice;

        public AudioFileReader AudioFile;


        public Player() => OutputDevice = new WaveOutEvent();

        public async Task PlayMusic(int miliseconds)
        {
            int countMilliseconds = miliseconds;
            while (true)
            {
                if (AudioFile != null)
                {
                    AudioFile.Dispose();
                }
                if (OutputDevice.PlaybackState != PlaybackState.Playing)
                {
                    AudioFile = new AudioFileReader(GetPathOnPriority(MainWindow.MusicList));

                    OutputDevice.Init(AudioFile);
                    OutputDevice.Play();
                }
                if (countMilliseconds < 0)
                {
                    AudioFile.Dispose ();
                    OutputDevice.Dispose();
                    break;
                }
                else
                {
                    await Task.Delay(1);
                    countMilliseconds--;
                }
            }

        }
        public async Task Play(MediaFile PathMediaFile)
        {

        }
        string GetPathOnPriority(List<Music> items)
        {
            int totalWeight = items.Sum(item => item.Priority);
            Random random = new Random();
            int randomValue = random.Next(totalWeight);

            foreach (Music music in items)
            {
                if (randomValue < music.Priority)
                {
                    return music.Path;
                }
                randomValue -= music.Priority;
            }
            return default(string);
        }
    }

}
