using System;
using System.Collections.Generic;
using System.Text;

namespace Booking.Core.DomainService
{
    public class MenuData
    {
        public string GetMenuItems()
        {
            return "[+] Neste dag\n" +
                   "[-] Forrige dag\n" +
                   "[B] Book time\n" +
                   "[Q] Avslutt\n" +
                   "Valg: ";
        }



    }
}
