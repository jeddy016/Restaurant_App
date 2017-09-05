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
                menu.Appetizers = Db.Appetizers.ToList();
                menu.Entrees = Db.Entrees.ToList();
                menu.Sides = Db.Sides.ToList();
                menu.Desserts = Db.Desserts.ToList();
                menu.Drinks = Db.Drinks.ToList();
            }
            return menu;
        }

        public static List<IMenuItem> GetOrderedItems(MenuViewModel model)
        {
            var menuItems = BuildMenu(model);
            menuItems.RemoveAll(x=> NotOrdered(x));
            return menuItems;
        }

        private static List<IMenuItem> BuildMenu(MenuViewModel model)
        {
            var menuItemLists = new List<List<IMenuItem>>()
            {
                model.Appetizers.ToList<IMenuItem>(),
                model.Desserts.ToList<IMenuItem>(),
                model.Drinks.ToList<IMenuItem>(),
                model.Entrees.ToList<IMenuItem>(),
                model.Sides.ToList<IMenuItem>()
            };
            return menuItemLists.SelectMany(x => x).ToList();
        }

        private static bool NotOrdered(IMenuItem item)
        {
            return item.Quantity < 1;
        }
    }
}