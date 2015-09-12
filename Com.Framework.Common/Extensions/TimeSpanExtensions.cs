using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Com.Framework.Common.Extensions
{
    public static class TimeSpanExtensions
    {
        public static bool IsBetween(this TimeSpan t, TimeSpan t1, TimeSpan t2)
        {
            if (t1 < t2)
                return t1 <= t && t <= t2;

            return !(t2 < t && t < t1);
        }
    }
}
