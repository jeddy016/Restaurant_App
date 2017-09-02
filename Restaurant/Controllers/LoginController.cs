using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Restaurant.Models;

namespace Restaurant.Controllers
{
    public class LoginController : Controller
    {
        // GET: /
        public ActionResult Login()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Login(User u)
        {
            if (ModelState.IsValid)
            {
                using (AppDbContext _context = new AppDbContext())
                {
                    var user = _context.Users.SingleOrDefault(s=>s.ServerNumber == u.ServerNumber && s.Password == u.Password);
                    if (user != null)
                    {
                        Session["serverName"] = user.FullName;
                        Session["serverId"] = user.Id;
                        return RedirectToAction("Index", "Home");
                    }
                }
            }
            ModelState.Clear();
            ViewBag.message = "Server Number or Password Incorrect";
            return View();
        }
    }
}