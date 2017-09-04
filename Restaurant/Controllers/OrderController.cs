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
                
                OrderDetailViewModel viewModel = new OrderDetailViewModel()
                {
                    Order = order,
                    OrderedItems = orderedMenuItems
                };
                
                return View("OrderDetail", viewModel);
            }

            TempData["message"] = "Orders must contain at least 1 item";
            return RedirectToAction("Index", "Home");
        }

        [HttpPost]
        public ActionResult SaveOrder(Order order)
        {
            OrderService.Save(order);

            return RedirectToAction("OrderHistory");
        }

        public ActionResult OrderHistory()
        {
            var viewModel = new OrderHistoryViewModel()
            {
                Orders = OrderService.GetOrderHistory()
            };
            return View(viewModel);
        }
    }
}