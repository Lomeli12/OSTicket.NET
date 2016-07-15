using System;
using OSTicket.NET;

namespace OSTicket.NET_Test {
    class MainClass {
        public static void Main(string[] args) {
            if (args != null && args.Length >= 2) {
                Console.WriteLine(args[0] + " | " + args[1]);
                var session = new OSTicketSession(args[0], args[1]);
                //var newTicket = new TicketInfo("TestBot", "bot@lomeli12.net", null, "Testing Library", "Library Test");
                //var response = session.submitTicket(newTicket, false);
                //Console.WriteLine(response);
                Console.WriteLine(session.getTicket(446753));
            }
        }
    }
}
