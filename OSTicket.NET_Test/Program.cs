using System;
using OSTicket.NET;

namespace OSTicket.NET_Test {
    class MainClass {
        public static void Main(string[] args) {
            if (args != null && args.Length >= 2) {
                Console.WriteLine(args[0] + " | " + args[1]);
                var session = new OSTicketSession(args[0], args[1]);
                var ticket = new Ticket("Dummy User", "dummy@mywebsite.net", "1234567890", "Test Ticket", "This is a test ticket, plz ignore");
                var id = session.submitTicket(ticket);
                var info = session.getTicketInfo(int.Parse(id));
                Console.WriteLine("ID: " + info.ID);
                Console.WriteLine("NUMBER: " + info.Number);
                Console.WriteLine("STATUS_ID: " + info.Status);
                Console.WriteLine("SUBJECT: " + info.Subject);
                Console.WriteLine("ASSIGNED STAFF: " + info.AssignedStaff);
                Console.WriteLine("OVERDUE: " + info.Overdue);
                Console.WriteLine("ANSWERED: " + info.Answered);
                Console.WriteLine("CREATION_DATE: " + info.CreationDate);
                Console.WriteLine("URL: " + info.URL);
            }
            Console.WriteLine("Press any key to continue...");
            Console.ReadKey();
        }
    }
}
