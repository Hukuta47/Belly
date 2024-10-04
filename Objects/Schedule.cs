using System.Collections.Generic;

namespace Belly.Objects
{
    public class Schedule
    {
        public Schedule(string Name)
        {
            this.Name = Name;
            bells = new List<Issue>();
        }
        public string Name { get; }
        public List<Issue> bells { get; set; } = new List<Issue>();

    }
}
