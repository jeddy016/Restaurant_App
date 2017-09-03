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
    [Authorize]
    public class OrderController : Controller
    {
        [HttpPost]
        public ActionResult BuildOrder(MenuViewModel model)
        {
            var subTotal = CalculateSubTotal(model);
            var discountAmount = decimal.Round((CalculateDiscount(model) * subTotal), 2, MidpointRounding.AwayFromZero);
            var preTaxAmount = decimal.Round((subTotal - discountAmount), 2, MidpointRounding.AwayFromZero);
            User server;

            try
            {
                server = GetUserById(int.Parse(Session["serverId"].ToString()));
            }
            catch (Exception){
                return RedirectToAction("Login", "Account");
            }

            Order order = new Order()
            {
                DateTime = DateTime.Now,
                Server = server,
                SubTotal = subTotal,
                Discount = discountAmount,
                PreTaxTotal = preTaxAmount >= 0.00M ? preTaxAmount : 0.00M
            };
   
            return View("OrderDetail", order);
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

        private decimal CalculateDiscount(MenuViewModel model)
        {
            var discountAmount = 0.00M;

            foreach (var discount in model.Discounts)
            {
                if (discount.Selected)
                {
                    discountAmount += discount.Percentage;
                }
            }
            return discountAmount / 100;
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

        public User GetUserById(int userId)
        {
            using (AppDbContext _context = new AppDbContext())
            {
                return _context.Users.SingleOrDefault(u => u.Id == userId);
            }
        }
    }
}