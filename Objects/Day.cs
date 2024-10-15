using System;
using System.Windows.Controls;

namespace Belly.Objects
{
    public class Day
    {
        public Day(DayOfWeek DayOfWeek)
        {
            this.DayOfWeek = DayOfWeek;
        }
        public DayOfWeek DayOfWeek { get; }
        public Schedule Schedule { get; set; }
        
    }
}
