using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;
using Restaurant.Models;
using Restaurant.Services;
using Restaurant.ViewModels;

namespace Restaurant.Controllers
{
    public class AccountController : Controller
    {
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
                        FormsAuthentication.SetAuthCookie(u.ServerNumber, false);
                        return RedirectToAction("Index", "Home");
                    }
                }
            }
            ModelState.Clear();
            ViewBag.message = "Server Number or Password Incorrect";
            return View();
        }

        public ActionResult LogOff()
        {
            FormsAuthentication.SignOut();
            return RedirectToAction("Login");
        }

        [Authorize]
        public ActionResult Users()
        {
            var model = new UsersViewModel()
            {
                Users = UserService.getUsers()
            };

            return View(model);
        }

        [Authorize]
        public ActionResult EditUser(User user)
        {
            return View(user);
        }

        [Authorize]
        public ActionResult DeleteUser(User user)
        {
            UserService.DeleteUser(user);

            var model = new UsersViewModel()
            {
                Users = UserService.getUsers()
            };

            return View("Users", model);
        }

        public ActionResult AddUser()
        {
            return View();
        }
    }
}