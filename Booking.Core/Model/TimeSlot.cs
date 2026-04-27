using System;
using System.Collections.Generic;
using System.Text;

namespace Booking.Core.Model
{
    public class TimeSlot
    {
        public Guid Id { get; private set; }
        public DateOnly Date { get; private set; }
        public int Hour { get; private set; }
        public string Description { get; private set; }

        public TimeSlot(DateOnly date, int hour, string description)
        {
            Id = Guid.NewGuid();
            Date = date;
            Hour = hour;
            Description = description;
        }

        // Trengs for JSON-deserialisering
        public TimeSlot()
        {
            Description = "";
        }

        public bool OverlapsWith(TimeSlot other)
        {
            return Date == other.Date && Hour == other.Hour;
        }
    }
}
