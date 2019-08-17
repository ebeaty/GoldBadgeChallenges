using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CafeMenuRepo
{
    public class CafeMenuRepository
    {
        private List<MenuItem> _menu = new List<MenuItem>();

        public void AddMenuItem(MenuItem newMenuItem)
        {
            _menu.Add(newMenuItem);
        }

        public List<MenuItem> GetMenu()
        {
            return _menu;
        }

        public bool RemoveItemFromMenu(int mealNumber)
        {
            MenuItem menuItem = GetItemByNumber(mealNumber);

            if (menuItem == null)
            {
                return false;
            }

            _menu.Remove(menuItem);
            return true;


        }

        public MenuItem GetItemByNumber(int mealNumber)
        {
            foreach (MenuItem menuItem in _menu)
            {
                if (menuItem.MealNumber == mealNumber)
                {
                    return menuItem;
                }
            }
            return null;
        }
        public void Seed()
        {
            MenuItem pasta = new MenuItem(1, "Alfredo", "Chicken broccoli alfredo pasta bake", "Chicken, Broccoli, Noodles, Tomatoes, Alfredo Sauce", 9.50);
            _menu.Add(pasta);
        }
    }
}
