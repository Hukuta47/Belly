
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

            // Инициализируем аудиофайл и воспроизведение один раз
            AudioFile = new AudioFileReader(GetPathOnPriority(MainWindow.MusicList));
            OutputDevice.Init(AudioFile);
            OutputDevice.Play();

            while (countMilliseconds > 0)
            {
                if (OutputDevice.PlaybackState != PlaybackState.Playing)
                {
                    OutputDevice.Init(AudioFile);
                    OutputDevice.Play();
                }


                await Task.Delay(75);

                // Вычисляем оставшееся время
                countMilliseconds = milliseconds - (int)stopwatch.ElapsedMilliseconds;
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
            await Task.Delay(60000);
            OutputDevice.Volume = MainWindow.SettingsValues.normalVolume;
            await Task.Delay(miliseconds - 60000);
            OutputDevice.Volume = MainWindow.SettingsValues.introOutroVolume;
            await Task.Delay(60000);
            OutputDevice.Volume = MainWindow.SettingsValues.normalVolume;
        }
    }

}
