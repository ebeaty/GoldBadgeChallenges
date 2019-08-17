using OutingRepository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OutingConsole
{
    class ProgramUI
    {
        private OutingRepo _outingRepo = new OutingRepo();

        public void Run()
        {
            Menu();
        }

        public void Menu()
        {
            bool keepRunning = true;
            while (keepRunning)
            {
                Console.WriteLine("Select an option:\n" +
                    "1.View all outings\n" +
                    "2.Add new outing\n" +
                    "3.View outing cost by type\n" +
                    "4.View total outing cost\n" +
                    "5.Exit");

                string input = Console.ReadLine();
                switch (input)
                {
                    case "1":
                        ViewAllOutings();
                        break;
                    case "2":
                        AddNewOuting();
                        break;
                    case "3":
                        CostByType();
                        break;
                    case "4":
                        TotalCost();
                        break;
                    case "5":
                        Console.WriteLine("Goodbye!");
                        keepRunning = false;
                        break;
                    default:
                        Console.WriteLine("Please enter a valid number");
                        break;
                }
                Console.WriteLine("Please Press Any Key to Continue...");
                Console.ReadKey();
                Console.Clear();
            }
        }

        public void ViewAllOutings()
        {
            Console.Clear();
            List<Outing> fullList = _outingRepo.GetList();

            foreach (Outing outing in fullList)
            {
                DateTime outingDate = outing.OutingDate;
                string dateFormat = outingDate.ToString("MM/dd/yyyy");
                Console.WriteLine($"{dateFormat} {outing.OutingType} Attendance:{outing.OutingAttendance} Total cost:${outing.TotalOutingCost}");
            }

        }
        public void AddNewOuting()
        {
            Console.Clear();
            Outing newOuting = new Outing();

            Console.WriteLine("Enter Event Type Number:\n" +
                "1.Golf\n" +
                "2.Bowling\n" +
                "3.Amusement Park\n" +
                "4.Concert");

            string eventTypeAsString = Console.ReadLine();
            int eventTypeAsInt = int.Parse(eventTypeAsString);
            newOuting.OutingType = (EventType)eventTypeAsInt;

            Console.WriteLine("Enter Attendance:");
            string attendanceAsString = Console.ReadLine();
            newOuting.OutingAttendance = int.Parse(attendanceAsString);

            Console.WriteLine("Enter Date of Outing (YYYY, MM, DD):");
            string dateAsString = Console.ReadLine();
            DateTime enteredDate = DateTime.Parse(dateAsString);
            newOuting.OutingDate = enteredDate;

            Console.WriteLine("Enter Cost Per Person:");
            string costAsString = Console.ReadLine();
            newOuting.CostPerPerson = double.Parse(costAsString);

            Console.WriteLine("Enter Total Outing Cost:");
            string totalCostAsString = Console.ReadLine();
            newOuting.TotalOutingCost = double.Parse(totalCostAsString);

            _outingRepo.AddNewOuting(newOuting);
        }

        public void CostByType()
        {
            Console.WriteLine($"Annual Golf Outings Cost: ${_outingRepo.CostByType(EventType.Golf)} \n" +
                $"Annual Bowling Outings Cost: ${_outingRepo.CostByType(EventType.Bowling)}\n" +
                $"Annual Amusement Park Outings Cost: ${_outingRepo.CostByType(EventType.AmusementPark)}\n" +
                $"Annual Concert Outings Cost: ${_outingRepo.CostByType(EventType.Concert)}");
        }

        public void TotalCost()
        {
            Console.WriteLine($"Annual Cost for All Outings: ${_outingRepo.TotalCost()}");
        }
    }
}

