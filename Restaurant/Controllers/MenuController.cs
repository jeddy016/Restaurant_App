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

        public ActionResult Edit(MenuItem item)
        {
            var viewModel = new MenuItemFormViewModel()
            {
                Id = item.Id,
                MenuItemTypeId = item.MenuItemTypeId
            };

            return View(viewModel);
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
            MenuItemFormViewModel viewModel = new MenuItemFormViewModel()
            {
                Types = MenuService.getItemTypes()
            };
            return View(viewModel);
        }

        public ActionResult Save(MenuItem item)
        {
            if (ModelState.IsValid)
            {
                if (MenuService.Save(item))
                {
                    var menuViewModel = new MenuViewModel()
                    {
                        Items = MenuService.GetMenuItems()
                    };
                    return View("Menu", menuViewModel);
                }

                ViewBag.message = "Item name already exists. Please choose another.";

                if (item.Id == 0)
                {
                    var newItemViewModel = new MenuItemFormViewModel()
                    {
                        Types = MenuService.getItemTypes()
                    };

                    return View("Add", newItemViewModel);
                }

                var editItemViewModel = new MenuItemFormViewModel()
                {
                    Id = item.Id,
                    MenuItemTypeId = item.MenuItemTypeId
                };

                return View("Edit", editItemViewModel);
            }

            ViewBag.message = "Error saving item. Try again.";

            var viewModel = new MenuViewModel()
            {
                Items = MenuService.GetMenuItems()
            };
            return View("Menu", viewModel);
        }
    }
}