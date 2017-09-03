using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Restaurant.Interfaces;
using Restaurant.Models;
using Restaurant.Services;
using Restaurant.ViewModels;

namespace Restaurant.Controllers
{
    [Authorize]
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            var viewModel = Menu.GetMenuItems();
            viewModel.Discounts = CashRegister.GetDiscounts();
            
            return View(viewModel);
        }
    }
}