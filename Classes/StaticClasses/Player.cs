
using System.Threading.Tasks;
using Belly.Objects;
using NAudio.Wave;
using System.Collections.Generic;
using System.Linq;
using System;
using System.Diagnostics;


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

        public async Task PlayMusic(int milliseconds, bool? volumeUpDown)
        {
            int countMilliseconds = milliseconds;
            var stopwatch = new Stopwatch();

            stopwatch.Start();

            if (volumeUpDown == true) startVolumeUpDown(milliseconds);


            while ((int)stopwatch.ElapsedMilliseconds < milliseconds)
            {
                if (OutputDevice.PlaybackState != PlaybackState.Playing)
                {
                    AudioFile = new AudioFileReader(GetPathOnPriority(MainWindow.MusicList));
                    OutputDevice.Init(AudioFile);
                    OutputDevice.Play();
                }


                await Task.Delay(1);

            }

            // Останавливаем воспроизведение и освобождаем ресурсы
            OutputDevice.Stop();
            AudioFile.Dispose();
            OutputDevice.Dispose();
        }
        public void Play(MediaFile MediaFile)
        {
            AudioFile = new AudioFileReader(MediaFile.Path);
            OutputDevice.Init(AudioFile);
            OutputDevice.Play();
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
            await Task.Delay(3000);
            await SmoothChangeVolume(MainWindow.SettingsValues.normalVolume, 3);
            await Task.Delay(miliseconds - (15000 + 1000));
            await SmoothChangeVolume(MainWindow.SettingsValues.introOutroVolume, 3);
            await Task.Delay(3000);
            await SmoothChangeVolume(0, 3);
            OutputDevice.Volume = MainWindow.SettingsValues.normalVolume;
        }
        async Task SmoothChangeVolume(float targetVolume, int duration_sec)
        {
            duration_sec *= 1000;

            float startVolume = OutputDevice.Volume;
            int steps = 100; 
            float stepSize = (targetVolume - startVolume) / steps;
            int delay = duration_sec / steps;

            for (int i = 0; i <= steps; i++)
            {
                OutputDevice.Volume += stepSize;
                await Task.Delay(delay);
            }

            OutputDevice.Volume = targetVolume;
        }
    }

}
