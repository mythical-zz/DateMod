using System;

namespace DateMod
{
    public static class Dates
    {
        public static string Short(this DateTime date)
        {
            return date.ToShortDateString();
        }

        public static string Long(this DateTime date)
        {
            return date.ToLongDateString();
        }

        public static string Day(this DateTime date)
        {
            return date.DayOfWeek.ToString();
        }

        public static DateTime AddWeeks(this DateTime date, int count)
        {
            return date.AddDays(7*count);
        }
    }
}