using System;
using System.Collections.Generic;
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
            var menuItems = MenuService.GetMenuItems();

            var viewModel = new NewOrderViewModel()
            {
                MenuItems = menuItems,
                Discounts = CashRegister.GetDiscounts()
            };

            return View(viewModel);
        }

        [HttpPost]
        public ActionResult BuildOrder(NewOrderViewModel model)
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
                    MenuItems = orderedMenuItems
                };

                Session["orderId"] = order.Id;
                ModelState.Clear();
                return View("OrderSummary", viewModel);
            }

            TempData["message"] = "Orders must contain at least 1 item";
            return RedirectToAction("NewOrder", "Order");
        }

        [HttpPost]
        public ActionResult SaveOrder(List<MenuItem> MenuItems)
        {
            var orderId = int.Parse(Session["orderId"].ToString());

            OrderService.SaveOrderedItems(orderId, MenuItems);

            Session.Remove("orderId");

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

        public ActionResult OrderDetail(int id)
        {
            var viewModel = new OrderDetailViewModel()
            {
                Order = OrderService.GetOrderById(id),
                MenuItems = OrderService.GetOrderedItemsById(id)
            };

            return View(viewModel);
        }
    }
}