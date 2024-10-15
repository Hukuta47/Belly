using System;
using System.Runtime.CompilerServices;
using System.Windows.Controls;

namespace Belly.Objects
{
    public class Day : TabItem
    {
        public Day(DayOfWeek dayOfWeek)
        {
            switch (dayOfWeek)
            {
                case DayOfWeek.Monday:
                    Header = "Понидельник";
                    break;
                case DayOfWeek.Tuesday:
                    Header = "Вторник";
                    break;
                case DayOfWeek.Wednesday:
                    Header = "Среда";
                    break;
                case DayOfWeek.Thursday:
                    Header = "Четверг";
                    break;
                case DayOfWeek.Friday:
                    Header = "Пятница";
                    break;
                case DayOfWeek.Saturday:
                    Header = "Суббота";
                    break;
            }
        }
        
    }
}
