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
        public ActionResult NewOrder()
        {
            var viewModel = MenuService.GetMenuItems();
            viewModel.Discounts = CashRegister.GetDiscounts();

            return View(viewModel);
        }

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
                return RedirectToAction("Login", "User");
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
            return RedirectToAction("NewOrder", "Order");
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