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

        internal static Enhancement ParseRowEnhancement(string row)
        {
            var columns = row.Split(',');
            if (columns.Length > 0 && columns.Length >= 8)
            {
                return new Enhancement()
                {
                    ticketID = columns[0],
                    summary = columns[1],
                    status = columns[2],
                    priority = columns[3],
                    submitter = columns[4],
                    assigned = columns[5],
                    watching = columns[6],
                    software = columns[7],
                    cost = double.Parse(columns[8]),
                    reason = columns[9],
                    estimate = double.Parse(columns[10])
                };
            }
            else
            {
                return new Enhancement();
            }
        }
               
        }

    }
