using CafeMenuRepo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestingProject
{
    class MenuUI
    {
        private CafeMenuRepository _cafeRepo = new CafeMenuRepository();
        public void Run()
        {
            Menu();
        }

        private void Menu()
        {
            bool keepRunning = true;
            while (keepRunning)
            {
                Console.WriteLine("Select an option:\n" +
                    "1.Add item to menu\n" +
                    "2.Delete item from menu\n" +
                    "3.View menu\n" +
                    "4.Exit");

                string input = Console.ReadLine();
                switch (input)
                {
                    case "1":
                        AddNewMenuItem();
                        break;
                    case "2":
                        DeleteMenuItem();
                        break;
                    case "3":
                        ViewMenu();
                        break;
                    case "4":
                        Console.WriteLine("Until next time!");
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
        public void AddNewMenuItem()
        {
            Console.Clear();
            MenuItem newMenuItem = new MenuItem();

            Console.WriteLine("Enter Meal Number:");
            string mealNumberAsString = Console.ReadLine();
            newMenuItem.MealNumber = int.Parse(mealNumberAsString);

            Console.WriteLine("Enter Meal Name:");
            newMenuItem.MealName = Console.ReadLine();

            Console.WriteLine("Enter Meal Description:");
            newMenuItem.MealDescription = Console.ReadLine();

            Console.WriteLine("List All Meal Ingredients:");
            newMenuItem.MealIngredients = Console.ReadLine();

            Console.WriteLine("Enter Meal Price (9.99, 10.50, 8, etc):");
            string mealPriceAsString = Console.ReadLine();
            newMenuItem.MealPrice = double.Parse(mealPriceAsString);


            _cafeRepo.AddMenuItem(newMenuItem);
        }

        public void ViewMenu()
        {
            Console.Clear();
            List<MenuItem> fullMenu = _cafeRepo.GetMenu();

            foreach (MenuItem menuItem in fullMenu)
            {
                Console.WriteLine($"{menuItem.MealNumber}. {menuItem.MealName}: {menuItem.MealDescription} contains {menuItem.MealIngredients}. ${menuItem.MealPrice}");
            }

        }

        public void DeleteMenuItem()
        {
            Console.Clear();
            ViewMenu();

            Console.WriteLine("Enter the number of the item you'd Like to remove from the menu:");
            string mealNumberAsString = Console.ReadLine();
            int mealNumber = int.Parse(mealNumberAsString);

            bool wasDeleted = _cafeRepo.RemoveItemFromMenu(mealNumber);

            if (wasDeleted)
            {
                Console.WriteLine("This meal was successfully deleted.");
            }
            else
            {
                Console.WriteLine("This meal was not found on the menu,");
            }
        }
    }
}
