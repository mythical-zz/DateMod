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
    }
}