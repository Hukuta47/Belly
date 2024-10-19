
using System.Threading.Tasks;
using Belly.Objects;
using NAudio.Wave;
using System.Collections.Generic;
using System.Linq;
using System;


namespace Belly.Classes.StaticClasses
{
    public class Player
    {
        public WaveOutEvent OutputDevice;
        public AudioFileReader AudioFile;


        public Player(float normalVolume, float introOutroVolume)
        {
            OutputDevice = new WaveOutEvent();
            OutputDevice.Volume = normalVolume;
        }

        public async Task PlayMusic(int miliseconds, bool? volumeUpDown)
        {
            int countMilliseconds = miliseconds;

            startVolumeUpDown(miliseconds);


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
        public async Task Play(MediaFile MediaFile)
        {
            if (AudioFile != null)
            {
                AudioFile.Dispose();
            }
            AudioFile = new AudioFileReader(MediaFile.Path);
            OutputDevice.Init(AudioFile);
            OutputDevice.Play();
            await Task.CompletedTask;
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
        async Task startVolumeUpDown(int miliseconds)
        {
            OutputDevice.Volume = MainWindow.SettingsValues.introOutroVolume;
            await Task.Delay(60000);
            OutputDevice.Volume = MainWindow.SettingsValues.normalVolume;
            await Task.Delay(miliseconds - 60000);
            OutputDevice.Volume = MainWindow.SettingsValues.introOutroVolume;
            await Task.Delay(60000);
            OutputDevice.Volume = MainWindow.SettingsValues.normalVolume;
        }
    }

}
