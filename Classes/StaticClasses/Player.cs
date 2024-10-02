﻿using NAudio.Wave;
using System;
using System.Threading.Tasks;

namespace Belly.Classes.StaticClasses
{
    public class Player
    {
        SettingsValues settings;


        static Mp3FileReader reader;
        static public WaveOut waveOut;

        public void SyncSettings()
        {



            if (waveOut != null) waveOut.Volume = settings.normalVolume;
        }

        public Player(SettingsValues settings)
        {
            this.settings = settings;
        }


        public async Task Play(string filePath, bool? volumeUpDown)
        {
            reader = new Mp3FileReader(filePath);
            waveOut = new WaveOut();
            
            waveOut.Init(reader);

            TimeSpan duration = reader.TotalTime;

            TimeSpan firstMinute = TimeSpan.FromMinutes(1);
            TimeSpan lastMinute = duration - TimeSpan.FromMinutes(1);


            waveOut.Volume = settings.normalVolume;
            waveOut.Play();

            if (volumeUpDown == true) await ControlVolumeAsync(reader, waveOut, firstMinute, lastMinute);
        }


        async Task ControlVolumeAsync(Mp3FileReader audioFile, WaveOut wave, TimeSpan firstMinute, TimeSpan lastMinute)
        {
            while (audioFile.CurrentTime < audioFile.TotalTime)
            {
                TimeSpan currentTime = audioFile.CurrentTime;

                if (currentTime <= firstMinute)
                {
                    // Увеличиваем громкость на первую минуту
                    wave.Volume = settings.ssintroOutroVolume;
                }
                else if (currentTime >= lastMinute)
                {
                    // Увеличиваем громкость на последнюю минуту
                    wave.Volume = settings.ssintroOutroVolume;
                }
                else
                {
                    // Обычная громкость
                    wave.Volume = settings.normalVolume;
                }

                // Ждём 1 миллисекунд перед следующей проверкой без блокировки основного потока
                await Task.Delay(1);
            }
        }



    }
    
}
