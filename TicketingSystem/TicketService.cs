using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TicketingSystem
{
    class TicketService
    {
        private string response;
        string file = "Tickets.csv";
        string[] ticketFiles = new string[] { "", "TaskTickets", "EnhancementTickets", "BugTickets", "Tickets" };

        public void TicketEntry()
        {
            string choice;
            string type;
            List<string> baseQuestions;

            CSVTicketParser ticketParser = new CSVTicketParser();

            do
            {
                Console.WriteLine("1) Read data from file.");
                Console.WriteLine("2) Create file from data.");
                Console.WriteLine("3) Search file from data");
                Console.WriteLine("Enter any other key to exit.");
                // input response
                choice = Console.ReadLine();

                if (choice == "1")
                {
                        ReadDataFromFile();  
                }
                else if (choice == "2")
                {
                    Console.WriteLine("Enter a ticket (Y/N)?");
                    response = Console.ReadLine().ToUpper();

                    if (response != "Y") { break; }

                    Console.WriteLine("Enter a ticket type (1:Task, 2:Enhancement, 3:Bug/Defect, 4:Other Ticket)");
                    type = Console.ReadLine();

                    baseQuestions = BaseQuestions();

                    if (type == "1")
                    {
                        Task task = new Task();
                        task.ticketID = baseQuestions[0];
                        task.summary = baseQuestions[1];
                        task.status = baseQuestions[2];
                        task.priority = baseQuestions[3];
                        task.submitter = baseQuestions[4];
                        task.assigned = baseQuestions[5];
                        task.watching = baseQuestions[6];

                        Console.WriteLine("Enter the Project Name: ");
                        task.projectName = Console.ReadLine();

                        //05/05/2005
                        Console.WriteLine("Enter the Due Date: (ex 05/05/2005)");
                        task.dueDate = Convert.ToDateTime(Console.ReadLine());

                        StreamWriter sw = new StreamWriter(ticketFiles[1] + ".csv", append: true);

                        sw.WriteLine("{0},{1},{2},{3},{4},{5},{6},{7},{8}",
                        task.ticketID, task.summary, task.status, task.priority, task.submitter, task.assigned, task.watching, task.projectName, task.dueDate);
                        sw.Close();
                    }
                    else if (type == "2")
                    {
                        Enhancement enhancement = new Enhancement();
                        enhancement.ticketID = baseQuestions[0];
                        enhancement.summary = baseQuestions[1];
                        enhancement.status = baseQuestions[2];
                        enhancement.priority = baseQuestions[3];
                        enhancement.submitter = baseQuestions[4];
                        enhancement.assigned = baseQuestions[5];
                        enhancement.watching = baseQuestions[6];

                        Console.WriteLine("Enter the Software: ");
                        enhancement.software = Console.ReadLine();

                        Console.WriteLine("Enter the Cost: ");
                        enhancement.cost = Convert.ToDouble(Console.ReadLine());

                        Console.WriteLine("Enter the Reason: ");
                        enhancement.reason = Console.ReadLine();

                        Console.WriteLine("Enter the Estimate: ");
                        enhancement.estimate = Convert.ToDouble(Console.ReadLine());

                        StreamWriter sw = new StreamWriter(ticketFiles[2] + ".csv", append: true);

                        sw.WriteLine("{0},{1},{2},{3},{4},{5},{6},{7},{8},{9},{10}",
                        enhancement.ticketID, enhancement.summary, enhancement.status, enhancement.priority, enhancement.submitter, enhancement.assigned, enhancement.watching, enhancement.software, enhancement.cost, enhancement.reason, enhancement.estimate);
                        sw.Close();
                    }
                    else if (type == "3")
                    {
                        BugDefect bugDefect = new BugDefect();
                        bugDefect.ticketID = baseQuestions[0];
                        bugDefect.summary = baseQuestions[1];
                        bugDefect.status = baseQuestions[2];
                        bugDefect.priority = baseQuestions[3];
                        bugDefect.submitter = baseQuestions[4];
                        bugDefect.assigned = baseQuestions[5];
                        bugDefect.watching = baseQuestions[6];

                        Console.WriteLine("Enter severity (1,2,3,4)");
                        bugDefect.severity = Console.ReadLine();

                        StreamWriter sw = new StreamWriter(ticketFiles[3] + ".csv", append: true);

                        sw.WriteLine("{0},{1},{2},{3},{4},{5},{6},{7}",
                        bugDefect.ticketID, bugDefect.summary, bugDefect.status, bugDefect.priority, bugDefect.submitter, bugDefect.assigned, bugDefect.watching, bugDefect.severity);
                        sw.Close();
                    }
                    else if (type == "4")
                    {
                        Ticket ticket = new Ticket();
                        ticket.ticketID = baseQuestions[0];
                        ticket.summary = baseQuestions[1];
                        ticket.status = baseQuestions[2];
                        ticket.priority = baseQuestions[3];
                        ticket.submitter = baseQuestions[4];
                        ticket.assigned = baseQuestions[5];
                        ticket.watching = baseQuestions[6];

                        StreamWriter sw = new StreamWriter(ticketFiles[4] + ".csv", append: true);

                        sw.WriteLine("{0},{1},{2},{3},{4},{5},{6}",
                        ticket.ticketID, ticket.summary, ticket.status, ticket.priority, ticket.submitter, ticket.assigned, ticket.watching);

                        sw.Close();
                    }

                    else
                    {
                        Console.WriteLine("Please enter 1, 2, 3 or 4 to specify the ticket type");
                    }
                    
                }
                else if (choice == "3")
                {
                    Console.WriteLine("Please choose a type of ticket to search: ");
                    Console.WriteLine("1) Bug Defects");
                    Console.WriteLine("2) Enhancements");
                    Console.WriteLine("3) Tasks");
                    Console.WriteLine("4) Other");
                    string userChoice = Console.ReadLine();

                    switch(userChoice)
                    {
                        case "1":
                            {

                                Console.WriteLine("Please choose how to search tickets:");
                                Console.WriteLine("1) Status");
                                Console.WriteLine("2) Priority");
                                Console.WriteLine("3) Submitter");
                                string response = Console.ReadLine();

                                switch (response)
                                {
                                    case "1":
                                        {
                                            Console.WriteLine("Please choose you status: ");
                                            Console.WriteLine("1) Low");
                                            Console.WriteLine("2) Medium");
                                            Console.WriteLine("3) High");
                                            string statusRes = Console.ReadLine();

                                            string fileBugDefect = "BugTickets.csv";
                                            var tickets = ticketParser.BDStatusLow(fileBugDefect, statusRes);
                                            foreach (var ticket in tickets)
                                            {
                                                Console.WriteLine(ticket.ticketID + " " + ticket.status);
                                            }
                                            break;
                                        }
                                    case "2":
                                        {
                                            Console.WriteLine("Please choose you status: ");
                                            Console.WriteLine("1) Low");
                                            Console.WriteLine("2) Medium");
                                            Console.WriteLine("3) High");
                                            string statusRes = Console.ReadLine();

                                            string fileBugDefect = "BugTickets.csv";
                                            var tickets = ticketParser.BDPriority(fileBugDefect, statusRes);
                                            foreach (var ticket in tickets)
                                            {
                                                Console.WriteLine(ticket.ticketID + " " + ticket.status);
                                            }
                                            break;
                                        }
                                    case "3":
                                        {
                                            Console.WriteLine("Please choose you status: ");
                                            Console.WriteLine("1) Low");
                                            Console.WriteLine("2) Medium");
                                            Console.WriteLine("3) High");
                                            string statusRes = Console.ReadLine();

                                            string fileBugDefect = "BugTickets.csv";
                                            var tickets = ticketParser.BDSubmiter(fileBugDefect, statusRes);
                                            foreach (var ticket in tickets)
                                            {
                                                Console.WriteLine(ticket.ticketID + " " + ticket.status);
                                            }
                                            break;
                                        }
                                    default:
                                        {
                                            break;
                                        }
                                }
                                break;
                            }
                        case "2":
                            {
                                Console.WriteLine("Please choose how to search tickets:");
                                Console.WriteLine("1) Status");
                                Console.WriteLine("2) Priority");
                                Console.WriteLine("3) Submitter");
                                string response = Console.ReadLine();

                                switch(response)
                                {
                                    case "1":
                                        {
                                            Console.WriteLine("Please choose you status: ");
                                            Console.WriteLine("1) Low");
                                            Console.WriteLine("2) Medium");
                                            Console.WriteLine("3) High");
                                            string statusRes = Console.ReadLine();

                                            string fileEnhancement = "EnhancementTickets.csv";
                                            var tickets = ticketParser.EHStatus(fileEnhancement, statusRes);
                                            foreach (var ticket in tickets)
                                            {
                                                Console.WriteLine(ticket.ticketID + " " + ticket.status);
                                            }
                                            break;
                                        }
                                    case "2":
                                        {
                                            Console.WriteLine("Please choose you status: ");
                                            Console.WriteLine("1) Low");
                                            Console.WriteLine("2) Medium");
                                            Console.WriteLine("3) High");
                                            string statusRes = Console.ReadLine();

                                            string fileEnhancement = "EnhancementTickets.csv";
                                            var tickets = ticketParser.EHPriority(fileEnhancement, statusRes);
                                            foreach (var ticket in tickets)
                                            {
                                                Console.WriteLine(ticket.ticketID + " " + ticket.status);
                                            }
                                            break;
                                        }
                                    case "3":
                                        {
                                            Console.WriteLine("Please choose you status: ");
                                            Console.WriteLine("1) Low");
                                            Console.WriteLine("2) Medium");
                                            Console.WriteLine("3) High");
                                            string statusRes = Console.ReadLine();

                                            string fileEnhancement = "EnhancementTickets.csv";
                                            var tickets = ticketParser.EHSubmitter(fileEnhancement, statusRes);
                                            foreach (var ticket in tickets)
                                            {
                                                Console.WriteLine(ticket.ticketID + " " + ticket.status);
                                            }
                                            break;
                                        }
                                    default:
                                        {
                                            break;
                                        }
                                }


                                break;
                            }
                        case "3":
                            {
                                Console.WriteLine("Please choose how to search tickets:");
                                Console.WriteLine("1) Status");
                                Console.WriteLine("2) Priority");
                                Console.WriteLine("3) Submitter");
                                string response = Console.ReadLine();

                                switch (response)
                                {
                                    case "1":
                                        {
                                            Console.WriteLine("Please choose you status: ");
                                            Console.WriteLine("1) Low");
                                            Console.WriteLine("2) Medium");
                                            Console.WriteLine("3) High");
                                            string statusRes = Console.ReadLine();

                                            string fileTask = "TaskTickets.csv";
                                            var tickets = ticketParser.TaskStatus(fileTask, statusRes);
                                            foreach (var ticket in tickets)
                                            {
                                                Console.WriteLine(ticket.ticketID + " " + ticket.status);
                                            }
                                            break;
                                        }
                                    case "2":
                                        {
                                            Console.WriteLine("Please choose you status: ");
                                            Console.WriteLine("1) Low");
                                            Console.WriteLine("2) Medium");
                                            Console.WriteLine("3) High");
                                            string statusRes = Console.ReadLine();

                                            string fileTask = "TaskTickets.csv";
                                            var tickets = ticketParser.TaskPriority(fileTask, statusRes);
                                            foreach (var ticket in tickets)
                                            {
                                                Console.WriteLine(ticket.ticketID + " " + ticket.status);
                                            }
                                            break;
                                        }
                                    case "3":
                                        {
                                            Console.WriteLine("Please choose you status: ");
                                            Console.WriteLine("1) Low");
                                            Console.WriteLine("2) Medium");
                                            Console.WriteLine("3) High");
                                            string statusRes = Console.ReadLine();

                                            string fileTask = "TaskTickets.csv";
                                            var tickets = ticketParser.TaskSubmitter(fileTask, statusRes);
                                            foreach (var ticket in tickets)
                                            {
                                                Console.WriteLine(ticket.ticketID + " " + ticket.status);
                                            }
                                            break;
                                        }
                                    default:
                                        {
                                            break;
                                        }
                                }


                                break;
                            }
                        case "4":
                            {
                                Console.WriteLine("Please choose how to search tickets:");
                                Console.WriteLine("1) Status");
                                Console.WriteLine("2) Priority");
                                Console.WriteLine("3) Submitter");
                                string response = Console.ReadLine();

                                switch (response)
                                {
                                    case "1":
                                        {
                                            Console.WriteLine("Please choose you status: ");
                                            Console.WriteLine("1) Low");
                                            Console.WriteLine("2) Medium");
                                            Console.WriteLine("3) High");
                                            string statusRes = Console.ReadLine();

                                            var tickets = ticketParser.TicketStatus(file, statusRes);
                                            foreach (var ticket in tickets)
                                            {
                                                Console.WriteLine(ticket.ticketID + " " + ticket.status);
                                            }
                                            break;
                                        }
                                    case "2":
                                        {
                                            Console.WriteLine("Please choose you status: ");
                                            Console.WriteLine("1) Low");
                                            Console.WriteLine("2) Medium");
                                            Console.WriteLine("3) High");
                                            string statusRes = Console.ReadLine();

                                            var tickets = ticketParser.TicketPriority(file, statusRes);
                                            foreach (var ticket in tickets)
                                            {
                                                Console.WriteLine(ticket.ticketID + " " + ticket.status);
                                            }
                                            break;
                                        }
                                    case "3":
                                        {
                                            Console.WriteLine("Please type in name of submitter: ");
                                            string statusRes = Console.ReadLine();

                                            var tickets = ticketParser.TicketSubmitter(file, statusRes);
                                            foreach (var ticket in tickets)
                                            {
                                                Console.WriteLine(ticket.ticketID + " " + ticket.status);
                                            }
                                            break;
                                        }
                                    default:
                                        {
                                            break;
                                        }
                                }


                                break;
                            }
                    }

                }

            } while (choice == "1" || choice == "2" || choice == "3"); // do while loop for option two, continue adding records
        }
        

        public static List<string> BaseQuestions() {

            Random rand = new Random();
            List<string> baseQuestions = new List<string>();
            int ticketId = rand.Next(0, 99999);


            baseQuestions.Add(ticketId.ToString());
            Console.WriteLine($"Creating a new ticket under Ticket ID : {ticketId.ToString()}");

            Console.WriteLine("Enter a new ticket summary: ");
            baseQuestions.Add(Console.ReadLine());

            Console.WriteLine("Enter the ticket status: ");
            baseQuestions.Add(Console.ReadLine());

            Console.WriteLine("Enter the ticket priority: ");
            baseQuestions.Add(Console.ReadLine());

            Console.WriteLine("Enter ticket submitter's full name: ");
            baseQuestions.Add(Console.ReadLine());

            Console.WriteLine("Enter full name ticket is to be assigned to: ");
            baseQuestions.Add(Console.ReadLine());

            Console.WriteLine("Enter full name of person watching the ticket: ");
            baseQuestions.Add(Console.ReadLine());

            return baseQuestions;
        }

        public void ReadDataFromFile()
        {
            Console.WriteLine("Enter the number of the type of file you want to read: ");
            Console.WriteLine("1.Task, 2.Enhancement, 3.Bug/Defect, 4.Other Ticket");
            int answer = Convert.ToInt32(Console.ReadLine());
            string fileToRead = ticketFiles[answer] + ".csv";

            if (File.Exists(fileToRead))
            {
                StreamReader ticket = new StreamReader(fileToRead);
                while (!ticket.EndOfStream)
                { 
                    string line = ticket.ReadLine();
                    // convert string to array
                    string[] arr = line.Split(',');
                    // display array data

                    if (answer == 1)
                    {
                        //task file
                        Console.WriteLine("TicketID, Summary, Status, Priority, Submitter, Assigned, Watching, Project Name, Due Date");
                        Console.WriteLine(arr[0] + ", " + arr[1] + ", " + arr[2] + ", " + arr[3] + ", " + arr[4] + ", " + arr[5] + ", " + arr[6] + ", " + arr[7] + ", " + arr[8]);
                        Console.WriteLine("\n");
                    }
                    else if (answer == 2)
                    {
                        //enhancement file
                        Console.WriteLine("TicketID, Summary, Status, Priority, Submitter, Assigned, Watching, Software, Cost, Reason, Estimate");
                        Console.WriteLine(arr[0] + ", " + arr[1] + ", " + arr[2] + ", " + arr[3] + ", " + arr[4] + ", " + arr[5] + ", " + arr[6] + ", " + arr[7] + ", " + arr[8] + ", " + arr[9] + ", " + arr[10]);
                        Console.WriteLine("\n");
                    }
                    else if (answer == 3)
                    {
                        //bug-defect file
                        Console.WriteLine("TicketID, Summary, Status, Priority, Submitter, Assigned, Watching, Severity");
                        Console.WriteLine(arr[0] + ", " + arr[1] + ", " + arr[2] + ", " + arr[3] + ", " + arr[4] + ", " + arr[5] + ", " + arr[6] + ", " + arr[7]);
                        Console.WriteLine("\n");
                    }
                    else if (answer == 4)
                    {
                        //other ticket file
                        Console.WriteLine("TicketID, Summary, Status, Priority, Submitter, Assigned, Watching");
                        Console.WriteLine(arr[0] + ", " + arr[1] + ", " + arr[2] + ", " + arr[3] + ", " + arr[4] + ", " + arr[5] + ", " + arr[6]);
                        Console.WriteLine("\n");
                    }
                }
            }
            else
            {
                Console.WriteLine("File does not exist");
            }

            
        }

    }
}
