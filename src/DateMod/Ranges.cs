using System;

namespace DateMod
{
    public static class Ranges
    {
        public static DateRange Query(this DateTime date)
        {
            if (date == DateTime.MinValue) date = Get.Today();

            return new DateRange
            {
                StartDate = new DateTime(date.Year, date.Month, date.Day),
                EndDate = new DateTime(date.Year, date.Month, date.Day + 1)
            };
        }
    }
}