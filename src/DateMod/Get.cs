using System;

namespace DateMod
{
    public class Get
    {
        public static DateTime Today()
        {
            return DateTime.Now;
        }

        public static DateTime Tomorrow()
        {
            return Today().AddDays(1);
        }

        public static DateTime Yesterday()
        {
            return Today().AddDays(-1);
        }

        public static DateRange ThisWeek()
        {
            var today = Today();
            var startDay = (int)today.DayOfWeek;
            var start = new DateTime(today.Year, today.Month, today.Day);

            start = start.AddDays(-(startDay - 1));

            var end = start.AddDays(6).AddHours(23).AddMinutes(59).AddSeconds(59);

            return new DateRange
                {
                    StartDate = start,
                    EndDate = end
                };
        }
    }
}