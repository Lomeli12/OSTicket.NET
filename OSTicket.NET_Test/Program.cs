using System;
using OSTicket.NET;

namespace OSTicket.NET_Test {
    class MainClass {
        public static void Main(string[] args) {
            if (args != null && args.Length >= 2) {
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
                Console.WriteLine("NUM_OF_RESPONSES: " + info.Messages.Count);
                if (info.OriginalMessage != null && info.OriginalMessage.MessageBody != null) {
                    Console.WriteLine("Original Message");
                    Console.WriteLine("Poster: " + info.OriginalMessage.Name);
                    if (info.OriginalMessage.MessageBody != null) {
                        Console.WriteLine("Message: " + info.OriginalMessage.MessageBody.body);
                        Console.WriteLine("Created: " + info.OriginalMessage.CreationDate);
                    }
                }
                if (info.Messages.Count > 0) {
                    int count = 0;
                    foreach (Message msg in info.Messages) {
                        Console.WriteLine("-------------------------");
                        Console.WriteLine("Message #" + (count + 1));
                        Console.WriteLine("Poster: " + msg.Name);
                        if (msg.MessageBody != null) {
                            Console.WriteLine("Message: " + msg.MessageBody.body);
                            Console.WriteLine("Created: " + msg.CreationDate);
                        }
                        ++count;
                    }
                }
            }
            Console.WriteLine("Press any key to continue...");
            Console.ReadKey();
        }
    }
}
