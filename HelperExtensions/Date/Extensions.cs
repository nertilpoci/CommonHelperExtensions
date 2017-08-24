using System;
using System.Collections.Generic;
using System.Text;

namespace HelperExtensions.Date
{
    public static class Extensions
    {
        /// <summary>
        /// Get the date to the next day of week
        /// </summary>
        public static DateTime Next(this DateTime current, DayOfWeek dayOfWeek)
        {
            int offsetDays = dayOfWeek - current.DayOfWeek;
            if (offsetDays <= 0) { offsetDays += 7; }
            DateTime result = current.AddDays(offsetDays);
            return result;
        }
        /// <summary>
        /// Check if a date is a working day
        /// </summary>
        public static bool IsWorkingDay(this DateTime date)
        {
            return date.DayOfWeek != DayOfWeek.Saturday && date.DayOfWeek != DayOfWeek.Sunday;
        }

        /// <summary>
        /// Check if date is weekend
        /// </summary>
        public static bool IsWeekend(this DateTime date)
        {
            return date.DayOfWeek == DayOfWeek.Saturday || date.DayOfWeek == DayOfWeek.Sunday;
        }

        /// <summary>
        /// Get next work Day
        /// </summary>
        public static DateTime NextWorkday(this DateTime date)
        {
            var nextDay = date;
            while (!nextDay.IsWorkingDay())
            {
                nextDay = nextDay.AddDays(1);
            }
            return nextDay;
        }

        /// <summary>
        /// Get a human readeable represantation of the time
        /// </summary>
        public static string ToHumanReadebleTime(this DateTime value)
        {
            var ts = new TimeSpan(DateTime.Now.Ticks - value.Ticks);
            double seconds = ts.TotalSeconds;
            if (seconds < 60)
            {
                return ts.Seconds == 1 ? "one second ago" : ts.Seconds + " seconds ago";
            }
            if (seconds < 120)
            {
               return "a minute ago";
            }
            if (seconds < 3300) //55 mins
            {
                return ts.Minutes + " minutes ago";
            }
            if (seconds < 6600) // 110 mins
            {
                return "an hour ago";
            }
            if (seconds < 86400) // 24 hours
            {
                return ts.Hours + " hours ago";
            }       
            if (seconds < 172800) // 48 hours
            {
                return "yesterday";
            }
            if (seconds < 2592000) // 30 days
            {
                return ts.Days + " days ago";
            }
            if (seconds < 31104000) // 12 months
            {
                int months = Convert.ToInt32(Math.Floor((double)ts.Days / 30));
                return months <= 1 ? "one month ago" : months + " months ago";
            }     
            var years = Convert.ToInt32(Math.Floor((double)ts.Days / 365));
            return years <= 1 ? "one year ago" : years + " years ago";

        }

        /// <summary>
        /// Check if year is leap year
        /// </summary>
        public static bool IsLeapYear(this DateTime value)
        {
            return (DateTime.DaysInMonth(value.Year, 2) == 29);
        }
    }
}
