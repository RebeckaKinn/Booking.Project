using System;
using System.Collections.Generic;
using System.Text;

namespace BookingUI
{
    internal class BookingApp
    {
        private readonly BookingService _bookingService;
        private readonly DateOnly _today;
        private DateOnly _currentDate;

        public BookingApp()
        {
            _bookingService = new BookingService();
            _today = DateOnly.FromDateTime(DateTime.Today);
            _currentDate = _today;
        }

        public void Run()
        {
            var isRunning = true;

            while (isRunning)
            {
                Console.Clear();
                Console.WriteLine(GetCurrentDayString(_currentDate));

                Console.WriteLine();
                Console.WriteLine(GetMenuItems());

                var key = Console.ReadKey(intercept: true).Key;

                if (key == ConsoleKey.Add) _currentDate = _currentDate.AddDays(1);
                else if (key == ConsoleKey.Subtract && _currentDate > _today) _currentDate = _currentDate.AddDays(-1);
                else if (key == ConsoleKey.B) _bookingService.BookHour(_currentDate);
                else if (key == ConsoleKey.Q) isRunning = false;
            }
        }

        private string GetMenuItems()
        {
            return "[+] Neste dag\n" +
                   "[-] Forrige dag\n" +
                   "[B] Book time\n" +
                   "[Q] Avslutt\n" +
                   "Valg: ";
        }

        //CORE
        private string GetCurrentDayString(DateOnly currentDate)
        {
            return $"Dato: {currentDate:dd.MM.yyyy}\n\n" +
                   string.Join("\n", _bookingService.GetDayStatus(currentDate).Select(status =>
                   {
                       var statusText = status.IsAvailable
                           ? "Ledig"
                           : $"Opptatt  ({status.Description})";
                       return $"{status.Hour:00}:00  {statusText}";
                   }));
        }
    }
}
