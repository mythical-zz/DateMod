using System;

namespace DateMod
{
    public static class Ranges
    {
        public static DateRange Range(this DateTime date)
        {
            if (date == DateTime.MinValue) date = Get.Today();

            return new DateRange
                {
                    StartDate = new DateTime(date.Year, date.Month, date.Day),
                    EndDate = new DateTime(date.Year, date.Month, date.Day, 23, 59, 59)
                };
        }

        public static DateRange Query(this DateTime date)
        {
            if (date == DateTime.MinValue) date = Get.Today();

            return new DateRange
            {
                StartDate = new DateTime(date.Year, date.Month, date.Day),
                EndDate = new DateTime(date.Year, date.Month, date.Day + 1)
            };
        }

        public static DateRange AddDays(this DateRange range, int count)
        {
            range.StartDate = range.StartDate.AddDays(count);
            range.EndDate = range.EndDate.AddDays(count);
            return range;
        }

        public static DateRange AddWeeks(this DateRange range, int count)
        {
            range.StartDate = range.StartDate.AddDays(7*count);
            range.EndDate = range.EndDate.AddDays(7*count);
            return range;
        }

        public static DateRange AddMonths(this DateRange range, int count)
        {
            range.StartDate = range.StartDate.AddMonths(count);
            range.EndDate = range.EndDate.AddMonths(count);
            return range;
        }

        public static DateRange AddYears(this DateRange range, int count)
        {
            range.StartDate = range.StartDate.AddYears(1);
            range.EndDate = range.EndDate.AddYears(1);
            return range;
        }
    }
}