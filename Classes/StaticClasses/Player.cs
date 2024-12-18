﻿using System.Threading.Tasks;
using Belly.Objects;
using NAudio.Wave;
using System.Collections.Generic;
using System.Linq;
using System;
using System.Diagnostics;
using Belly.Pages;


namespace Belly.Classes.StaticClasses
{
    public class Player
    {
        public WaveOutEvent OutputDevice;
        public AudioFileReader AudioFile;


        public Player(float basicVolume)
        {
            OutputDevice = new WaveOutEvent();
            OutputDevice.Volume = basicVolume;
        }

        public async Task PlayMusic(int milliseconds, bool? volumeUpDown)
        {
            if (Main.MusicList != null)
            {
                int countMilliseconds = milliseconds;
                var stopwatch = new Stopwatch();

                stopwatch.Start();
                if (volumeUpDown == true) startVolumeUpDown(milliseconds);


                while ((int)stopwatch.ElapsedMilliseconds < milliseconds)
                {
                    if (OutputDevice.PlaybackState != PlaybackState.Playing)
                    {
                        Music Music = GetPathOnPriority(Main.MusicList);

                        AudioFile = new AudioFileReader(Music.Path);
                        OutputDevice.Init(AudioFile);
                        OutputDevice.Play();
                        MainPage.label_nameMediaFileText.Content = $"Воспроизводиться {Music.Name}";
                    }


                    await Task.Delay(1);

                }

                // Останавливаем воспроизведение и освобождаем ресурсы
                OutputDevice.Stop();
                AudioFile.Dispose();
                OutputDevice.Dispose();
                MainPage.label_nameMediaFileText.Content = $"";
            }

            OutputDevice.Volume = Main.SettingsValues.basicVolume;
        }
        public async Task Play(MediaFile MediaFile)
        {
            MainPage.label_nameMediaFileText.Content = $"Воспроизводиться {MediaFile.Name}";
            OutputDevice.Volume = Main.SettingsValues.basicVolume;
            if (MediaFile != null)
            {
                AudioFile = new AudioFileReader(MediaFile.Path);
                OutputDevice.Init(AudioFile);
                OutputDevice.Play();
            }
            await Task.Delay((int)AudioFile.TotalTime.TotalMilliseconds);
            MainPage.label_nameMediaFileText.Content = $"";
        }
        Music GetPathOnPriority(List<Music> items)
        {
            int totalWeight = items.Sum(item => item.Priority);
            Random random = new Random();
            int randomValue = random.Next(totalWeight);

            foreach (Music music in items)
            {
                if (randomValue < music.Priority)
                {
                    return music;
                }
                randomValue -= music.Priority;
            }
            return default;
        }
        async Task startVolumeUpDown(int miliseconds)
        {
            int offset =
                (Main.SettingsValues.durationIntroOutroVolume +
                Main.SettingsValues.durationTransitionToMiddleVolume +
                Main.SettingsValues.durationTransitionToUpVolume +
                Main.SettingsValues.durationIntroOutroVolume +
                Main.SettingsValues.durationTransitionToEndVolume + 1) * 1000;

            OutputDevice.Volume = Main.SettingsValues.introOutroVolume;
            await Task.Delay(Main.SettingsValues.durationIntroOutroVolume * 1000);
            await SmoothChangeVolume(Main.SettingsValues.middleVolume, Main.SettingsValues.durationTransitionToMiddleVolume);
            
            await Task.Delay(miliseconds - offset); 
            
            await SmoothChangeVolume(Main.SettingsValues.introOutroVolume, Main.SettingsValues.durationTransitionToUpVolume);
            await Task.Delay(Main.SettingsValues.durationIntroOutroVolume * 1000);
            await SmoothChangeVolume(0, Main.SettingsValues.durationTransitionToEndVolume);
            OutputDevice.Volume = Main.SettingsValues.basicVolume;
        }
        async Task SmoothChangeVolume(float targetVolume, int duration_sec)
        {
            duration_sec *= 1000;

            float startVolume = OutputDevice.Volume;
            int steps = 100; 
            float stepSize = (targetVolume - startVolume) / steps;
            int delay = duration_sec / steps;

            for (int i = -1; i <= steps; i++)
            {
                OutputDevice.Volume += stepSize;
                await Task.Delay(delay);
            }

            OutputDevice.Volume = targetVolume;
        }
    }

}
