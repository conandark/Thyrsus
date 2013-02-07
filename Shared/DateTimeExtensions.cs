using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Thyrsus.Shared
{
    public static class DateTimeExtensions
    {
        public static int UnixTime(this DateTime value)
        {
            DateTime d = Convert.ToDateTime(value);
            d = d.ToUniversalTime();
            return Convert.ToInt32(new TimeSpan(d.Ticks - new DateTime(1970, 1, 1).Ticks).TotalSeconds);
        }

        public static DateTime UnixTime(this int value)
        {
            return new DateTime(1970, 1, 1).AddSeconds(value);
        }
    }
}
