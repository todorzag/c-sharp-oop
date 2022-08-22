using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DateModifier
{
    internal class DateModifier
    {
        public int DayDifference { get; set; }

        public DateModifier() { }

        public void GetDateDifference(string date1, string date2)
        {
            DateTime dateTime1 = ReturnDateTimeFromString(date1);
            DateTime dateTime2 = ReturnDateTimeFromString(date2);

            TimeSpan diff = dateTime2.Subtract(dateTime1);

            DayDifference = Math.Abs(diff.Days);
        }

        public DateTime ReturnDateTimeFromString(string date)
        {
            string[] split = date.Split(" ");

            int year = int.Parse(split[0]);
            int month = int.Parse(split[1]);
            int day = int.Parse(split[2]);

            return new DateTime(year, month, day);
        }
    }
}
