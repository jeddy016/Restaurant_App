using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
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

        public static List<MenuItemType> getItemTypes()
        {
            using (var Db = new AppDbContext())
            {
                return Db.MenuItemTypes.ToList();
            }
        }
        
        public static List<MenuItem> GetOrderedItems(NewOrderViewModel menu)
        {
            menu.MenuItems.RemoveAll(x=> NotOrdered(x));
            return menu.MenuItems;
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

        public static bool Save(MenuItem item)
        {
            bool saved = false;

            using (var Db = new AppDbContext())
            {
                
                if(item.Id != 0)
                {
                    var itemInDb = Db.MenuItems.Find(item.Id);

                    if (item.Name == itemInDb.Name)
                    {
                        itemInDb.Price = item.Price;
                        saved = true;
                    }
                    else if (Unique(item.Name))
                    {
                        itemInDb.Name = item.Name;
                        itemInDb.Price = item.Price;
                        saved = true;
                    }
                }
                else if (Unique(item.Name))
                {
                    Db.MenuItems.Add(item);
                    saved = true;
                }
                Db.SaveChanges();
                return saved;
            }
        }

        private static bool Unique(string name)
        {
            using (var Db = new AppDbContext())
            {
                return Db.MenuItems.SingleOrDefault(i => i.Name == name) == null;
            }
        }

    }
}