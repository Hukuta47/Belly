namespace Belly.Objects
{
    public class Bell
    {
        public Bell(string Name, string PlayTime, MediaData Media) 
        {
            this.Name = Name;
            this.PlayTime = PlayTime;
            this.Media = Media;
        }
        public string Name { get; set; }
        public string PlayTime { get; set; }
        public MediaData Media { get; set; }
        
    }
}
