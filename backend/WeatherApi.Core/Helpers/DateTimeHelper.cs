using System;
using System.Collections.Generic;
using System.Text;

namespace WeatherApi.Core.Helpers
{
    public static class DateTimeExtensions
    {
        /// <summary>
        /// Convert Unix time value to a DateTime object.
        /// </summary>
        /// <param name="unixtime">The Unix time stamp you want to convert to DateTime.</param>
        /// <returns>Returns a DateTime object that represents value of the Unix time.</returns>
        public static DateTime ToDateTime(this int unixtime) => DateTimeOffset.FromUnixTimeSeconds(unixtime).UtcDateTime;

        public static bool IsTodaysDate(this DateTime date) => date.Day == DateTime.Now.Day && date.Month == DateTime.Now.Month && date.Year == DateTime.Now.Year;

    }
}
