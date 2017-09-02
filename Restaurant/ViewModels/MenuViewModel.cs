using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Restaurant.Models;

namespace Restaurant.ViewModels
{
    public class MenuViewModel
    {
        public List<Entree> Entrees { get; set; }
        public List<Appetizer> Appetizers { get; set; }
        public List<Side> Sides { get; set; }
        public List<Dessert> Desserts { get; set; }
        public List<Drink> Drinks { get; set; }

        public MenuViewModel GetMenuItems()
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
    }
}