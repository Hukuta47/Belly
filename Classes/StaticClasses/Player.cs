﻿using NAudio.Wave;
using System;
using System.Threading.Tasks;

namespace Belly.Classes.StaticClasses
{
    public static class Player
    {
        public static float introOutroVolume;
        public static float normalVolume;

        static Mp3FileReader reader;
        static public WaveOut waveOut;

        public static void SyncSettings()
        {
            introOutroVolume = SettingsValues.introOutroVolume;
            normalVolume = SettingsValues.normalVolume;

            if (waveOut != null) waveOut.Volume = SettingsValues.normalVolume;
        }
        public static async Task Play(string filePath, bool? volumeUpDown)
        {
            reader = new Mp3FileReader(filePath);
            waveOut = new WaveOut();
            
            waveOut.Init(reader);

            TimeSpan duration = reader.TotalTime;

            TimeSpan firstMinute = TimeSpan.FromMinutes(1);
            TimeSpan lastMinute = duration - TimeSpan.FromMinutes(1);


            waveOut.Volume = SettingsValues.normalVolume;
            waveOut.Play();

            if (volumeUpDown == true) await ControlVolumeAsync(reader, waveOut, firstMinute, lastMinute);
        }


        static async Task ControlVolumeAsync(Mp3FileReader audioFile, WaveOut wave, TimeSpan firstMinute, TimeSpan lastMinute)
        {
            while (audioFile.CurrentTime < audioFile.TotalTime)
            {
                TimeSpan currentTime = audioFile.CurrentTime;

                if (currentTime <= firstMinute)
                {
                    // Увеличиваем громкость на первую минуту
                    wave.Volume = introOutroVolume;
                }
                else if (currentTime >= lastMinute)
                {
                    // Увеличиваем громкость на последнюю минуту
                    wave.Volume = introOutroVolume;
                }
                else
                {
                    // Обычная громкость
                    wave.Volume = normalVolume;
                }

                // Ждём 1 миллисекунд перед следующей проверкой без блокировки основного потока
                await Task.Delay(1);
            }
        }



    }
    
}