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
            using (AppDbContext _context = new AppDbContext())
            {
                menu.Appetizers = _context.Appetizers.ToList();
                menu.Entrees = _context.Entrees.ToList();
                menu.Sides = _context.Sides.ToList();
                menu.Desserts = _context.Desserts.ToList();
                menu.Drinks = _context.Drinks.ToList();
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