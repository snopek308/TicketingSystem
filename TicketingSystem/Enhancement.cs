using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TicketingSystem
{
    class Enhancement :Ticket
    {
        public string software { get; set; }
        public double cost { get; set; }
        public string reason { get; set; }
        public double estimate { get; set; }


    }
}
