using Booking.Core.Model;
using System;
using System.Collections.Generic;
using System.Text;
using System.Text.Json;

namespace Booking.Core.DomainService
{
    public class JsonBookingRepository
    {
        private const string FilePath = "bookings.json";
        private static readonly JsonSerializerOptions JsonOptions = new() { WriteIndented = true };
        

        public static List<TimeSlot> GetAll()
        {
            if (!File.Exists(FilePath))
            {
                File.WriteAllText(FilePath, "[]");
                return new List<TimeSlot>();
            }

            var json = File.ReadAllText(FilePath);

            if (string.IsNullOrWhiteSpace(json))
            {
                File.WriteAllText(FilePath, "[]");
                return new List<TimeSlot>();
            }

            return JsonSerializer.Deserialize<List<TimeSlot>>(json) ?? new List<TimeSlot>();
        }

        public static void Add(TimeSlot booking)
        {
            var bookings = GetAll();
            bookings.Add(booking);

            var json = JsonSerializer.Serialize(bookings, JsonOptions);
            File.WriteAllText(FilePath, json);
        }
    }
}
