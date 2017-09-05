using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using Restaurant.Interfaces;
using Restaurant.Models;
using Restaurant.ViewModels;

namespace Restaurant.Services
{
    public class MenuService
    {
        public static List<MenuItem> GetMenuItems()
        {
            using (AppDbContext Db = new AppDbContext())
            {
                return Db.MenuItems.ToList();
            }
        }

        public static List<MenuItem> GetOrderedItems(NewOrderViewModel menu)
        {
            menu.Items.RemoveAll(x=> NotOrdered(x));
            return menu.Items;
        }

        private static bool NotOrdered(MenuItem item)
        {
            return item.Quantity < 1;
        }

        public static void Delete(MenuItem item)
        {
            using (var Db = new AppDbContext())
            {
                Db.Entry(item).State = EntityState.Deleted;
                Db.SaveChanges();
            }
        }

        public static void Edit(MenuItem item)
        {
            
        }
    }
}