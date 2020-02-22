using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TicketingSystem
{
    class Program
    {
        static void Main(string[] args)
        {
            TicketService ticketService = new TicketService();
            ticketService.TicketEntry();
            //ticket newTicket = new ticket();
            //newTicket.userInput();
            //newTicket.process();
        }
    }
}
