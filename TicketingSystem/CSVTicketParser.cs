using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TicketingSystem
{
    class CSVTicketParser
    {
        public List<Ticket> ProcessTicket(string path)
        {
            return File.ReadAllLines(path)
                .Skip(1)
                .Where(row => row.Length > 0)
                .Select(Ticket.ParseRow).ToList();
        }

        public List<Task> ProcessTask(string path)
        {
            return File.ReadAllLines(path)
                .Skip(1)
                .Where(row => row.Length > 0)
                .Select(Task.ParseRowTask).ToList();
        }

        public List<Enhancement> ProcessEnhancement(string path)
        {
            return File.ReadAllLines(path)
                .Skip(1)
                .Where(row => row.Length > 0)
                .Select(Enhancement.ParseRowEnhancement).ToList();
        }

        public List<BugDefect> ProcessBugDefect(string path)
        {
            return File.ReadAllLines(path)
                .Skip(1)
                .Where(row => row.Length > 0)
                .Select(BugDefect.ParseRowBugDefect).ToList();
        }

        public List<BugDefect> BDStatusLow(string path, string selection)
        {
            var status = "";
            if(selection == "1")
            {
                status = "Low";
            }
            else if (selection ==  "2")
            {
                status = "Medium";
            }
            else if (selection == "3")
            {
                status = "High";
            }
            else
            {
                Console.WriteLine("This is an invalid selection");
            }

            return File.ReadAllLines(path)
                .Skip(1)
                .Select(BugDefect.ParseRowBugDefect)
                .Where(s => s.status == status)
                .ToList();
        }

        public List<BugDefect> BDPriority(string path, string selection)
        {
            var priority = "";
            if (selection == "1")
            {
                priority = "Low";
            }
            else if (selection == "2")
            {
                priority = "Medium";
            }
            else if (selection == "3")
            {
                priority = "High";
            }
            else
            {
                Console.WriteLine("This is an invalid selection");
            }

            return File.ReadAllLines(path)
                .Skip(1)
                .Select(BugDefect.ParseRowBugDefect)
                .Where(p => p.priority == priority)
                .ToList();
        }

        public List<BugDefect> BDSubmiter(string path, string selection)
        {
            var submitter = "";
            if (selection == "1")
            {
                submitter = "Low";
            }
            else if (selection == "2")
            {
                submitter = "Medium";
            }
            else if (selection == "3")
            {
                submitter = "High";
            }
            else
            {
                Console.WriteLine("This is an invalid selection");
            }

            return File.ReadAllLines(path)
                .Skip(1)
                .Select(BugDefect.ParseRowBugDefect)
                .Where(p => p.submitter == submitter)
                .ToList();
        }

        public List<Enhancement> EHStatus(string path, string selection)
        {
            var status = "";
            if (selection == "1")
            {
                status = "Low";
            }
            else if (selection == "2")
            {
                status = "Medium";
            }
            else if (selection == "3")
            {
                status = "High";
            }
            else
            {
                Console.WriteLine("This is an invalid selection");
            }

            return File.ReadAllLines(path)
                .Skip(1)
                .Select(Enhancement.ParseRowEnhancement)
                .Where(s => s.status == status)
                .ToList();
        }

                public List<Enhancement> EHPriority(string path, string selection)
                    {
                        var priority = "";
                        if (selection == "1")
                        {
                            priority = "Low";
                        }
                        else if (selection == "2")
                        {
                            priority = "Medium";
                        }
                        else if (selection == "3")
                        {
                            priority = "High";
                        }
                        else
                        {
                            Console.WriteLine("This is an invalid selection");
                        }

                        return File.ReadAllLines(path)
                            .Skip(1)
                            .Select(Enhancement.ParseRowEnhancement)
                            .Where(s => s.priority == priority)
                            .ToList();
                    }

        public List<Enhancement> EHSubmitter(string path, string selection)
        {
            var submitter = "";
            selection = submitter;

            return File.ReadAllLines(path)
                .Skip(1)
                .Select(Enhancement.ParseRowEnhancement)
                .Where(s => s.submitter == submitter)
                .ToList();
        }

        public List<Task> TaskStatus(string path, string selection)
        {
            var status = "";
            if (selection == "1")
            {
                status = "Low";
            }
            else if (selection == "2")
            {
                status = "Medium";
            }
            else if (selection == "3")
            {
                status = "High";
            }
            else
            {
                Console.WriteLine("This is an invalid selection");
            }

            return File.ReadAllLines(path)
                .Skip(1)
                .Select(Task.ParseRowTask)
                .Where(s => s.status == status)
                .ToList();
        }

        public List<Task> TaskPriority(string path, string selection)
        {
            var priority = "";
            if (selection == "1")
            {
                priority = "Low";
            }
            else if (selection == "2")
            {
                priority = "Medium";
            }
            else if (selection == "3")
            {
                priority = "High";
            }
            else
            {
                Console.WriteLine("This is an invalid selection");
            }

            return File.ReadAllLines(path)
                .Skip(1)
                .Select(Task.ParseRowTask)
                .Where(s => s.priority == priority)
                .ToList();
        }

        public List<Task> TaskSubmitter(string path, string selection)
        {
            var submitter = "";
            selection = submitter;

            return File.ReadAllLines(path)
                .Skip(1)
                .Select(Task.ParseRowTask)
                .Where(s => s.submitter == submitter)
                .ToList();
        }

        public List<Ticket> TicketStatus(string path, string selection)
        {
            var status = "";
            if (selection == "1")
            {
                status = "Low";
            }
            else if (selection == "2")
            {
                status = "Medium";
            }
            else if (selection == "3")
            {
                status = "High";
            }
            else
            {
                Console.WriteLine("This is an invalid selection");
            }

            return File.ReadAllLines(path)
                .Skip(1)
                .Select(Ticket.ParseRow)
                .Where(s => s.status == status)
                .ToList();
        }

        public List<Ticket> TicketPriority(string path, string selection)
        {
            var priority = "";
            if (selection == "1")
            {
                priority = "Low";
            }
            else if (selection == "2")
            {
                priority = "Medium";
            }
            else if (selection == "3")
            {
                priority = "High";
            }
            else
            {
                Console.WriteLine("This is an invalid selection");
            }

            return File.ReadAllLines(path)
                .Skip(1)
                .Select(Ticket.ParseRow)
                .Where(s => s.priority == priority)
                .ToList();
        }

        public List<Ticket> TicketSubmitter(string path, string selection)
        {
            var submitter = "";
            selection = submitter;

            return File.ReadAllLines(path)
                .Skip(1)
                .Select(Ticket.ParseRow)
                .Where(s => s.submitter == submitter)
                .ToList();
        }

    }
}
