using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TicketingSystem
{
    class BugDefect : Ticket
    {
        public string severity { get; set; }

        internal static BugDefect ParseRowBugDefect(string row)
        {
            var columns = row.Split(',');
            if(columns.Length > 0 && columns.Length >= 8)
            {
                return new BugDefect()
                {
                    ticketID = columns[0],
                    summary = columns[1],
                    status = columns[2],
                    priority = columns[3],
                    submitter = columns[4],
                    assigned = columns[5],
                    watching = columns[6],
                    severity = columns[7],
                };
            } else
            {
                return new BugDefect();
            }
        }
    }


}
