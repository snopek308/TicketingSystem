using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TicketingSystem
{
    class Ticket
    {
        //creating getters and setters for the base ticket class
        //should always use getters and setters
        public string ticketID { get; set; }
        public string summary { get; set; }
        public string status { get; set; }
        public string priority { get; set; }
        public string submitter { get; set; }
        public string assigned { get; set; }
        public string watching { get; set; }
        

    }
}
