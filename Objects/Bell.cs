namespace Belly.Objects
{
    public class Bell
    {
        public Bell(string Name, string PlayTime, Track track) 
        {
            this.Name = Name;
            this.PlayTime = PlayTime;
            this.track = track;
        }
        public string Name { get; set; }
        public string PlayTime { get; set; }
        public Track track { get; set; }
        
    }
}
