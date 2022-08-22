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
            DateTime dateTime1 = DateTime.Parse(date1);
            DateTime dateTime2 = DateTime.Parse(date2);

            TimeSpan diff = dateTime2.Subtract(dateTime1);

            DayDifference = Math.Abs(diff.Days);
        }
    }
}
