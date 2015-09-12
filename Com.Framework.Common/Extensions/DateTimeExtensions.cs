using System;

namespace Com.Framework.Common.Extensions
{
    public static class DateTimeExtensions
    {
        public static bool IsBetween(this DateTime d, DateTime d1, DateTime d2)
        {
            if (d1.TimeOfDay < d2.TimeOfDay)
                return d1.TimeOfDay <= d.TimeOfDay && d.TimeOfDay <= d2.TimeOfDay;

            return !(d2.TimeOfDay < d.TimeOfDay && d.TimeOfDay < d1.TimeOfDay);
        }
    }
}
