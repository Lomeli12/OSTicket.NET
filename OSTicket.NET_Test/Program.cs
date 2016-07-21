using System;
using OSTicket.NET;

namespace OSTicket.NET_Test {
    class MainClass {
        public static void Main(string[] args) {
            if (args != null && args.Length >= 2) {
                Console.WriteLine(args[0] + " | " + args[1]);
                var session = new OSTicketSession(args[0], args[1]);
                var info = session.getTicketInfo(446753);
                Console.WriteLine("ID: " + info.ID);
                Console.WriteLine("NUMBER: " + info.Number);
                Console.WriteLine("STATUS_ID: " + info.Status);
                Console.WriteLine("SUBJECT: " + info.Subject);
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
