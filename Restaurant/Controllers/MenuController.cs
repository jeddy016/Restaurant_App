using System.Web.Mvc;
using Restaurant.Models;
using Restaurant.Services;
using Restaurant.ViewModels;

namespace Restaurant.Controllers
{
    [Authorize]
    public class MenuController : Controller
    {
        public ActionResult Menu()
        {
            var viewModel = new MenuViewModel()
            {
                Items = MenuService.GetMenuItems()
            };

            return View(viewModel);
        }

        public ActionResult NewMenuItem()
        {
            return View();
        }

        public ActionResult Edit(MenuItem item)
        {
            MenuService.Edit(item);

            var viewModel = new MenuViewModel()
            {
                Items = MenuService.GetMenuItems()
            };

            return View("Menu", viewModel);
        }

        public ActionResult Delete(MenuItem item)
        {
            MenuService.Delete(item);

            var viewModel = new MenuViewModel()
            {
                Items = MenuService.GetMenuItems()
            };

            return View("Menu", viewModel);

        }

        public ActionResult Add()
        {
            return View();
        }
    }
}