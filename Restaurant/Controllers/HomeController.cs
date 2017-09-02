using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Restaurant.Models;
using Restaurant.ViewModels;

namespace Restaurant.Controllers
{
    [Authorize]
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            var viewModel = GetMenuItems();
            
            return View(viewModel);
        }

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