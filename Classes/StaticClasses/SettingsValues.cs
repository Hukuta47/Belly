namespace Belly.Classes.StaticClasses
{
    public class SettingsValues
    {
        public float introOutroVolume { get; set; }
        public float normalVolume { get; set;}
        public SettingsValues(float introOutroVolume, float normalVolume)
        {
            this.introOutroVolume = introOutroVolume;
            this.normalVolume = normalVolume;
        }

    }
}
