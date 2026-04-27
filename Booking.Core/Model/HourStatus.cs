using System;
using System.Collections.Generic;
using System.Text;

namespace Booking.Core.Model
{
    public class HourStatus
    {
        public int Hour { get; }
        public bool IsAvailable { get; }
        public string? Description { get; }

        public HourStatus(int hour, bool isAvailable, string? description)
        {
            Hour = hour;
            IsAvailable = isAvailable;
            Description = description;
        }
    }
}
