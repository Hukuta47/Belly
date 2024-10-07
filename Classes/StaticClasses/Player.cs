
using System.Threading.Tasks;
using Belly.Enums;
using Belly.Objects;
using NAudio.Wave;

namespace Belly.Classes.StaticClasses
{
    public class Player
    {

        public SettingsValues _settings;

        public WaveOut waveOut;

        public Mp3FileReader reader;

        public async Task Play(IssueType issueType, 4                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                     MediaFile mediaFile)
        {
            switch (issueType)
            {
                case IssueType.Music:
                    break;
                case IssueType.Audio:
                    break;
            }
        }




    }

}
