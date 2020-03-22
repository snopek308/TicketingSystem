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

        internal static Ticket ParseRow(string row)
        {
            var columns = row.Split(',');
            if (columns.Length > 0 && columns.Length >= 8)
            {
                return new Task()
                {
                    ticketID = columns[0],
                    summary = columns[1],
                    status = columns[2],
                    priority = columns[3],
                    submitter = columns[4],
                    assigned = columns[5],
                    watching = columns[6]
                };
            }
            else
            {
                return new Task();
            }
        }
    }
}
