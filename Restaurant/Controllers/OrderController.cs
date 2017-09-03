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
                server = AccountController.GetUserById(Session["serverId"].ToString());
            }
            catch (NullReferenceException)
            {
                return RedirectToAction("Login", "Account");
            }

            var orderedMenuItems = Menu.GetOrderedItems(model);

            if (orderedMenuItems.Count > 0)
            {
                var subTotal = CashRegister.CalculateSubTotal(orderedMenuItems);
                var discountAmount = CashRegister.CalculateDiscount(model.SelectedDiscount, subTotal);
                var preTaxAmount = CashRegister.FormatAsCurrency(subTotal - discountAmount);

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

            TempData["message"] = "Orders must contain at least 1 item";

            return RedirectToAction("Index", "Home");
        }

        public ActionResult OrderHistory()
        {
            return View();
        }

    }
}