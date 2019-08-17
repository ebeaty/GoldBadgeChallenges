using Badge;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BadgeConsole
{
    class BadgeUI
    {
        private BadgeRepo _badgeRepo = new BadgeRepo();
        
        public void Menu()
        {
            _badgeRepo.Seed();
            bool stillRunning = true;
            while (stillRunning)
            {


                Console.WriteLine("Please Choose From Options:\n" +
                    "1. Add a badge \n" +
                    "2. Edit a badge \n" +
                    "3. List all badges \n" +
                    "4. Exit");


                string input = Console.ReadLine();
                switch (input)
                {
                    case "1":
                        //add a badge
                        AddBadge();
                        break;
                    case "2":
                        //edit a badge
                        EditBadge();
                        break;
                    case "3":
                        //list all badges
                        PrintListOfRooms();
                        break;
                    case "4":
                        stillRunning = false;
                        break;
                    default:
                        //bad value
                        break;

                }
            }
        }


        public void EditBadge()
        {

            Console.WriteLine("What is the badge number to edit?");
            string badgeIdAsString = Console.ReadLine();
            int badgeID = int.Parse(badgeIdAsString);
            Console.WriteLine($"{badgeID} has access to: ");
            List<string> rooms = _badgeRepo.GetListOfBadges()[badgeID];
            foreach (string room in rooms)
            {
                Console.WriteLine($"{room}");
            }
            bool stillAddingRooms = true;
            while (stillAddingRooms)
            {

                Console.WriteLine("What would you like to do? \n" +
                    "1.Remove a door \n" +
                    "2.Add a door \n" +
                    "3.Return to Main Menu");
                string input = Console.ReadLine();
                switch (input)
                {
                    case "1":
                        //remove a door
                        RoomRemove(rooms);
                        break;
                    case "2":
                        //add a door
                        RoomAdd(badgeID);
                        break;
                    case "3":
                        stillAddingRooms = false;
                        break;
                    default:
                        //bad value
                        break;
                }
            }


        }
        public void PrintListOfRooms()
        {
            foreach (var badgeID in _badgeRepo.GetListOfBadges())
            {
                Console.Write("Badge number : " + badgeID.Key);
                foreach (string room in badgeID.Value)
                {
                    Console.Write(" " + room);
                }
                Console.WriteLine();
            }
        }

        public void AddBadge()
        {
            Console.WriteLine("What is the number on the badge:");
            string badgeIdAsString = Console.ReadLine();
            int badgeID = int.Parse(badgeIdAsString);
            _badgeRepo.AddBadgeToDictionary(badgeID);
            RoomAdd(badgeID);
        }

        public void RoomAdd(int badgeID)
        {
            Console.WriteLine("List a room this badge has access to:");
            string roomAccess = Console.ReadLine();
            _badgeRepo.AddRoomToBadge(badgeID, roomAccess);
            Console.WriteLine("Any other rooms? (y/n)");
            string moreRooms = Console.ReadLine();
            while (moreRooms == "y")
            {
                Console.WriteLine("List a room this badge has access to:");
                roomAccess = Console.ReadLine();
                _badgeRepo.AddRoomToBadge(badgeID, roomAccess);
                Console.WriteLine("Any other rooms? (y/n)");
                moreRooms = Console.ReadLine();
            }
        }

        public void RoomRemove(List<string> rooms)
        {
            Console.WriteLine("Which door would you like to remove?");
            string input = Console.ReadLine();
            rooms.Remove(input);
        }

        public void Run()
        {
            Menu();
        }

    }
}
