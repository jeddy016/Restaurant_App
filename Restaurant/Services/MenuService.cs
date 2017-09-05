using System.Collections.Generic;
using System.Linq;
using Restaurant.Interfaces;
using Restaurant.Models;
using Restaurant.ViewModels;

namespace Restaurant.Services
{
    public class MenuService
    {
        public static MenuViewModel GetMenuItems()
        {
            var menu = new MenuViewModel();
            using (AppDbContext Db = new AppDbContext())
            {
                menu.Items = Db.MenuItems.ToList();
                //menu.Appetizers = Db.Appetizers.ToList();
                //menu.Entrees = Db.Entrees.ToList();
                //menu.Sides = Db.Sides.ToList();
                //menu.Desserts = Db.Desserts.ToList();
                //menu.Drinks = Db.Drinks.ToList();
            }
            return menu;
        }

        public static List<MenuItem> GetOrderedItems(MenuViewModel menu)
        {
            menu.Items.RemoveAll(x=> NotOrdered(x));
            return menu.Items;
        }

        private static bool NotOrdered(MenuItem item)
        {
            return item.Quantity < 1;
        }
    }
}