using System;
using System.Web.Mvc;
using Restaurant.Models;
using Restaurant.Services;
using Restaurant.ViewModels;

namespace Restaurant.Controllers
{
    [Authorize]
    public class OrderController : Controller
    {
        [HttpPost]
        public ActionResult BuildOrder(MenuViewModel model)
        {
            User server;

            try
            {
                server = UserService.GetUserById(Session["serverId"].ToString());
            }
            catch (NullReferenceException)
            {
                return RedirectToAction("Login", "Account");
            }

            var orderedMenuItems = MenuService.GetOrderedItems(model);

            if (orderedMenuItems.Count > 0)
            {
                Order order = OrderService.Build(orderedMenuItems, server, model.SelectedDiscount);
                
                return View("OrderDetail", order);
            }

            TempData["message"] = "Orders must contain at least 1 item";
            return RedirectToAction("Index", "Home");
        }

        public ActionResult OrderHistory()
        {
            return View();
        }

    }
}