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
            Session["serverName"] = null;
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
            var viewModel = new EditUserFormViewModel()
            {
                Id = user.Id,
                FirstName = user.FirstName,
                LastName = user.LastName,
            };
            return View("EditUserForm", viewModel);
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
            return View("NewUserForm");
        }

        [HttpPost]
        public ActionResult SaveNewUser(NewUserFormViewModel viewModel)
        {
            if (ModelState.IsValid)
            {
                var user = new User()
                {
                    Id = viewModel.Id ?? default(int),
                    Active = true,
                    FirstName = viewModel.FirstName,
                    LastName = viewModel.LastName,
                    ServerNumber = UserService.GenerateServerNumber(),
                    Password = viewModel.Password
                };

                UserService.Save(user);

                var model = new UsersViewModel()
                {
                    Users = UserService.getUsers()
                };

                return View("Users", model);
            }

            ViewBag.message = "Error creating server. Try again.";
            return View("NewUserForm");
        }

        [HttpPost]
        public ActionResult SaveUser(EditUserFormViewModel viewModel)
        {
            if (ModelState.IsValid)
            {
                var user = new User()
                {
                    Id = viewModel.Id ?? default(int),
                    Active = true,
                    FirstName = viewModel.FirstName,
                    LastName = viewModel.LastName,
                    ServerNumber = UserService.GenerateServerNumber()
                };

                UserService.Save(user);

                if (int.Parse(Session["serverId"].ToString()) == user.Id && Session["serverName"].ToString() != user.FullName)
                {
                    Session["serverName"] = user.FullName;
                }

                var model = new UsersViewModel()
                {
                    Users = UserService.getUsers()
                };

                return View("Users", model);
            }

            ViewBag.message = "Error editing server. Try again.";
            return View("EditUserForm");
        }
    }
}