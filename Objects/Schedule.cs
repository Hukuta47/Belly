using System.Collections.Generic;

namespace Belly.Objects
{
    public class Schedule
    {
        public Schedule(string Name)
        {
            this.Name = Name;
            bells = new List<Bell>();
        }
        public string Name { get; }
        public List<Bell> bells { get; set; }

    }
}
