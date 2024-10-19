using System;

namespace Belly.Objects
{
    public class Day
    {
        public Day(DayOfWeek DayOfWeek)
        {
            this.DayOfWeek = DayOfWeek;
        }
        public DayOfWeek DayOfWeek { get; }
        public string Name
        {
            get
            {
                switch (DayOfWeek)
                {
                    case DayOfWeek.Monday: return "Понидельник";
                    case DayOfWeek.Tuesday: return "Вторник";
                    case DayOfWeek.Wednesday: return "Среда";
                    case DayOfWeek.Thursday: return "Четверг";
                    case DayOfWeek.Friday: return "Пятница";
                    case DayOfWeek.Saturday: return "Суббота";
                }
                return Name;
            }
        }
        public int scheduleNum { get; set; } = -1;
    }
}
