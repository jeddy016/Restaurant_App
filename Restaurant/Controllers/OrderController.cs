using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Restaurant.Controllers
{
    public class OrderController : Controller
    {
        [HttpPost]
        public ActionResult PlaceOrder()
        {
            return RedirectToAction("OrderHistory");
        }

        public ActionResult OrderHistory()
        {
            return View();
        }
    }
}