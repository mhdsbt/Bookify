using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
using System.Text;
using System.Threading.Tasks;

namespace Bookify.Domain.Entities.Booking
{
    public class DateRange
    {
        public DateOnly Start { get; set; }
        public DateOnly End { get; set; }

        public int LengthDays => End.DayNumber - Start.DayNumber;

        public static DateRange Create(DateOnly start, DateOnly end)
        {
            if (start > end)
                throw new ArgumentException("End Date Precedes start date");

            return new DateRange
            {
                Start = start,
                End = end
            };
        }
    }
}
