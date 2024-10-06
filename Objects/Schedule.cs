using System.Collections.Generic;

namespace Belly.Objects
{
    public class Schedule
    {
        public Schedule(string Name)
        {
            this.Name = Name;
            Issues = new List<Issue>();
        }
        public string Name { get; }
        public List<Issue> Issues { get; set; } = new List<Issue>();

    }
}
