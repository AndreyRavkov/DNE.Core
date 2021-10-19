using System;
using System.Collections.Generic;
using System.Globalization;

namespace DNE.Core.DateTime
{
    public static class Extensions
    {
        /// <summary>
        /// Convert unix time milliseconds to DateTime
        /// </summary>
        /// <param name="unixTimeMilliseconds">source unix time milliseconds</param>
        /// <returns>DateTime</returns>
        public static System.DateTime ToDateTime(this long unixTimeMilliseconds)
        {
            return DateTimeOffset.FromUnixTimeMilliseconds(unixTimeMilliseconds).UtcDateTime;
        }

        /// <summary>
        /// Convert DateTime to unit time milliseconds
        /// </summary>
        /// <param name="value">source DateTime</param>
        /// <returns></returns>
        public static long ToUnixTimeMilliseconds(this System.DateTime value)
        {
            return ((DateTimeOffset) value).ToUnixTimeMilliseconds();
        }

        /// <summary>
        /// Convert DateTime to string with InvariantCulture
        /// </summary>
        /// <param name="dateTime"></param>
        /// <returns></returns>
        public static string ToStringExt(this System.DateTime dateTime)
        {
            return dateTime.ToString(CultureInfo.InvariantCulture);
        }

        /// <summary>
        /// Convert string to DateTime with InvariantCulture
        /// </summary>
        /// <param name="value">source string</param>
        /// <returns>DateTime</returns>
        public static System.DateTime ToDateTimeExt(this string value)
        {
            return System.DateTime.Parse(value, CultureInfo.InvariantCulture);
        }
        
        /// <summary>
        /// Add bank days to the source datetime value
        /// </summary>
        /// <param name="day">source datetime value</param>
        /// <param name="addDaysValue">count days to add</param>
        /// <returns>DateTime</returns>
        public static System.DateTime AddBankingDays(this System.DateTime day, int addDaysValue)
        {
            var resultDay = day;
            while (addDaysValue != 0)
            {
                resultDay = resultDay.AddDays(1);
                if (resultDay.DayOfWeek != DayOfWeek.Sunday && resultDay.DayOfWeek != DayOfWeek.Saturday)
                {
                    addDaysValue--;
                }
            }
            return resultDay;
        }
        
        /// <summary>
        /// Get count of bank days between two dates
        /// </summary>
        /// <param name="start">start date</param>
        /// <param name="end">end date</param>
        /// <returns>int</returns>
        public static int GetBankingDays(System.DateTime start, System.DateTime end)
        {
            var days = new List<System.DateTime>();
            for (var date = start.AddDays(1); date <= end; date = date.AddDays(1))
            {
                if (date.DayOfWeek != DayOfWeek.Sunday && date.DayOfWeek != DayOfWeek.Saturday)
                {
                    days.Add(date);
                }
            }

            return days.Count;
        }
    }
}