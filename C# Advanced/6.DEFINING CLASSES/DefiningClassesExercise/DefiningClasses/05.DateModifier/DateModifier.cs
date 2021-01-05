using System;
using System.Collections.Generic;
using System.Globalization;
using System.Text;

namespace _05.DateModifier
{
    public class DateModifier
    {
        public DateModifier(string dateOne, string dateTwo)
        {
            this.FirstDate = DateTime.Parse(dateOne);
            this.SecondDate = DateTime.Parse(dateTwo);
        }
        public DateTime FirstDate{ get; set; }
        public DateTime SecondDate{ get; set; }
        public int DaysDifference()
        {
            var days = (this.FirstDate - this.SecondDate).TotalDays;
            return (int)Math.Abs(days);
        }



    }
}
