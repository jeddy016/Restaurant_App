using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Restaurant.Interfaces;
using Restaurant.Models;
using Restaurant.ViewModels;

namespace Restaurant.Controllers
{
    public class OrderController : Controller
    {
        [HttpPost]
        public ActionResult PlaceOrder(MenuViewModel model)
        {
            Order order = new Order();
        
            order.SubTotal = CalculateSubTotal(model);
             
            return RedirectToAction("OrderDetail", order);
        }

        public ActionResult OrderDetail(Order order)
        {

            return View(order);
        }

        public ActionResult OrderHistory()
        {
            return View();
        }

        public decimal CalculateSubTotal(MenuViewModel model)
        {
            var menuList = Flatten(model);
            var subTotal = 0.00M;

            foreach (var menuItem in menuList)
            {
                subTotal += menuItem.Price * menuItem.Quantity;
            }

            return subTotal;
        }

        public List<IMenuItem> Flatten(MenuViewModel model)
        {
            var listOfLists = new List<List<IMenuItem>>()
            {
                model.Appetizers.ToList<IMenuItem>(),
                model.Desserts.ToList<IMenuItem>(),
                model.Drinks.ToList<IMenuItem>(),
                model.Entrees.ToList<IMenuItem>(),
                model.Sides.ToList<IMenuItem>()
            };
            return listOfLists.SelectMany(x => x).ToList();
        }
    }
}