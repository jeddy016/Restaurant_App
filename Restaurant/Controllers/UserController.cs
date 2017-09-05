using System.Web.Mvc;
using System.Web.Security;
using Restaurant.Models;
using Restaurant.Services;
using Restaurant.ViewModels;

namespace Restaurant.Controllers
{
    public class UserController : Controller
    {
        public ActionResult Login()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Login(User login)
        {
            if (ModelState.IsValid)
            {
                var user = UserService.ValidateLogin(login);

                if (user != null)
                {
                    Session["serverName"] = user.FullName;
                    Session["serverId"] = user.Id;
                    FormsAuthentication.SetAuthCookie(user.ServerNumber, false);

                    return RedirectToAction("NewOrder", "Order");
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
            UserService.Delete(user);

            var model = new UsersViewModel()
            {
                Users = UserService.getUsers()
            };

            return View("Users", model);
        }

        [Authorize]
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

        [Authorize]
        public ActionResult ChangePassword()
        {
            if (Session["serverId"] != null)
            {
                var viewModel = new ChangePasswordViewModel()
                {
                    Id = int.Parse(Session["serverId"].ToString())
                };

                return View("ChangePassword", viewModel);
            }

            return RedirectToAction("Login");
        }

        [HttpPost]
        public ActionResult SavePassword(ChangePasswordViewModel viewModel)
        {
            if (ModelState.IsValid)
            {
                var user = new User()
                {
                    Password = viewModel.Password,
                    Id = viewModel.Id
                };

                UserService.UpdatePassword(user);

                return RedirectToAction("NewOrder", "Order");
            }

            ViewBag.message = "Error updating Password. Try again.";

            return View("ChangePassword");
        }
    }
}