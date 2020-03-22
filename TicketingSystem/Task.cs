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

        internal static Task ParseRowTask(string row)
        {
            var columns = row.Split(',');
            if(columns.Length > 0 && columns.Length >= 8)
            {
                return new Task()
                {
                    ticketID = columns[0],
                    summary = columns[1],
                    status = columns[2],
                    priority = columns[3],
                    submitter = columns[4],
                    assigned = columns[5],
                    watching = columns[6],
                    projectName = columns[7],
                    dueDate = DateTime.Parse(columns[8])
            };
        }else
            {
             return new Task();
            }
        }
    }
}

