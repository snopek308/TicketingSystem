using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TicketingSystem
{
    class Task : Ticket
    {
        public string projectName { get; set; }
        public DateTime dueDate { get; set; }
    }
}
