namespace Belly.Classes.StaticClasses
{
    public class SettingsValues
    {
        public static float introOutroVolume;
        public static float normalVolume;

        public float _introOutroVolume { get; set; }
        public float _normalVolume { get; set; }

        public SettingsValues(float introOutroVolume, float normalVolume)
        {
            _introOutroVolume = introOutroVolume;
            _normalVolume = normalVolume;

            introOutroVolume = _introOutroVolume;
            normalVolume = _normalVolume;
        }
        public static void SetSettings(float sintroOutroVolume, float snormalVolume)
        {
            introOutroVolume = sintroOutroVolume;
            normalVolume = snormalVolume;
        }
        public void SyncData()
        {
            
        }




    }
}
