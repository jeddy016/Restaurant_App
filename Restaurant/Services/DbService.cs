using System;
using System.Collections.Generic;
using System.Linq;
using Restaurant.Models;

namespace Restaurant.Services
{
    public class DbService
    {
        public static bool Empty()
        {
            using (var Db = new AppDbContext())
            {
                return Db.Users.ToList().Count < 1;
            }
        }

        public static void SeedDb()
        {
            using (var Db = new AppDbContext())
            {
                Db.Database.ExecuteSqlCommand("DBCC CHECKIDENT('MenuItems', RESEED, 0)");
                Db.Database.ExecuteSqlCommand("DBCC CHECKIDENT('MenuItemTypes', RESEED, 0)");
                Db.Database.ExecuteSqlCommand("DBCC CHECKIDENT('Orders', RESEED, 0)");
                Db.Database.ExecuteSqlCommand("DBCC CHECKIDENT('Users', RESEED, 0)");
                Db.Database.ExecuteSqlCommand("DBCC CHECKIDENT('Taxes', RESEED, 0)");
                Db.Database.ExecuteSqlCommand("DBCC CHECKIDENT('Discounts', RESEED, 0)");
                Db.Database.ExecuteSqlCommand("DBCC CHECKIDENT('OrderedMenuItems', RESEED, 0)");

                var users = new List<User>()
                {
                    new User()
                    {
                        Id = 1,
                        Active = true,
                        FirstName = "Rick",
                        LastName = "Sanchez",
                        Password = "guest",
                        ServerNumber = "1234"
                    },
                    new User()
                    {
                        Id = 2,
                        Active = true,
                        FirstName = "Bird",
                        LastName = "Person",
                        Password = "guest",
                        ServerNumber = "1235"
                    },
                    new User()
                    {
                        Id = 3,
                        Active = true,
                        FirstName = "Morty",
                        LastName = "Smith",
                        Password = "guest",
                        ServerNumber = "1236"
                    },
                    new User()
                    {
                        Id = 4,
                        Active = true,
                        FirstName = "Pickle",
                        LastName = "Rick",
                        Password = "guest",
                        ServerNumber = "1237"
                    }
                };
                
                Db.Users.AddRange(users);

                Db.SaveChanges();

                AddMenuItemTypes(Db);
                AddMenuItems(Db);
                AddDiscounts(Db);
                AddTaxes(Db);
                AddOrders(Db);
                AddOrderedItems(Db);
                
            }
        }

        private static void AddOrderedItems(AppDbContext Db)
        {
            var list = new List<OrderedMenuItem>()
            {
                new OrderedMenuItem()
                {
                    MenuItemId = 1,
                    OrderId = 1,
                    Quantity = 1
                },
                new OrderedMenuItem()
                {
                    MenuItemId = 13,
                    OrderId = 1,
                    Quantity = 6
                },
                new OrderedMenuItem()
                {
                    MenuItemId = 4,
                    OrderId = 1,
                    Quantity = 1
                },
                new OrderedMenuItem()
                {
                    MenuItemId= 9,
                    OrderId = 1,
                    Quantity = 2
                },
                new OrderedMenuItem()
                {

                    MenuItemId= 11,
                    OrderId = 1,
                    Quantity = 1
                },
                new OrderedMenuItem()
                {
                    MenuItemId= 12,
                    OrderId = 1,
                    Quantity = 2
                },
                new OrderedMenuItem()
                {
                    MenuItemId= 13,
                    OrderId = 1,
                    Quantity = 1
                },
                new OrderedMenuItem()
                {
                    MenuItemId= 14,
                    OrderId = 1,
                    Quantity = 1
                },
                new OrderedMenuItem()
                {
                    MenuItemId= 7,
                    OrderId = 2,
                    Quantity = 2
                },
                new OrderedMenuItem()
                {
                    MenuItemId= 13,
                    OrderId = 2,
                    Quantity = 1
                },
            };
            Db.OrderedMenuItems.AddRange(list);
            Db.SaveChanges();
        }

        private static void AddOrders(AppDbContext Db)
        {
            var list = new List<Order>()
            {
                new Order()
                {
                    DateTime = new DateTime(2017, 09, 05, 7, 30, 22),
                    SubTotal = 19.50M,
                    Discount = 2.85M,
                    PreTaxTotal = 13.57M,
                    Tax = 2.58M,
                    Total = 13.57M,
                    ServerId = 1
                },
                new Order()
                {
                    DateTime = new DateTime(2017, 07, 23, 9, 01, 37),
                    SubTotal = 8.98M,
                    Discount = 0,
                    PreTaxTotal = 8.98M,
                    Tax = 1.44M,
                    Total = 7.54M,
                    ServerId = 2
                }
            };
            Db.Orders.AddRange(list);
            Db.SaveChanges();
        }

        private static void AddTaxes(AppDbContext Db)
        {
            var list = new List<Tax>()
            {
                new Tax()
                {
                    Name = "City",
                    Percentage = 4
                },
                new Tax()
                {
                    Name = "County",
                    Percentage = 3
                },
                new Tax()
                {
                    Name = "State",
                    Percentage = 1
                }
            };
            Db.Taxes.AddRange(list);
            Db.SaveChanges();
        }
        
        private static void AddDiscounts(AppDbContext Db)
        {
            var list = new List<Discount>()
            {
                new Discount()
                {
                    Name = "Early Bird",
                    Percentage = 5
                },
                new Discount()
                {
                    Name = "Sweet Beard",
                    Percentage = 10
                },
                new Discount()
                {
                    Name = "Veteran",
                    Percentage = 15
                },
                new Discount()
                {
                    Name = "Half Off",
                    Percentage = 50
                },
                new Discount()
                {
                    Name = "Full Comp",
                    Percentage = 100
                }
            };
            Db.Discounts.AddRange(list);
            Db.SaveChanges();
        }

        private static void AddMenuItems(AppDbContext Db)
        {
            var items = new List<MenuItem>()
            {
                new MenuItem()
                {
                    MenuItemTypeId = 1,
                    Name = "Fried Pickles",
                    Price = 2.50M,
                    Quantity = 0
                },new MenuItem()
                {
                    MenuItemTypeId = 1,
                    Name = "Jalapeno Poppers",
                    Price = 3.00M,
                    Quantity = 0
                },new MenuItem()
                {
                    MenuItemTypeId = 1,
                    Name = "Salsa",
                    Price = 1.99M,
                    Quantity = 0
                },new MenuItem()
                {
                    MenuItemTypeId = 2,
                    Name = "CheeseBurger",
                    Price = 5.00M,
                    Quantity = 0
                },new MenuItem()
                {
                    MenuItemTypeId = 2,
                    Name = "Corn Dog",
                    Price = 2.75M,
                    Quantity = 0
                },new MenuItem()
                {
                    MenuItemTypeId = 2,
                    Name = "Pizza Rolls",
                    Price = 1.00M,
                    Quantity = 0
                },new MenuItem()
                {
                    MenuItemTypeId = 2,
                    Name = "Pizza",
                    Price = 2.99M,
                    Quantity = 0
                },new MenuItem()
                {
                    MenuItemTypeId = 3,
                    Name = "Fries",
                    Price = 0.50M,
                    Quantity = 0
                },new MenuItem()
                {
                    MenuItemTypeId = 3,
                    Name = "Mac N Cheese",
                    Price = 1.50M,
                    Quantity = 0
                },
                new MenuItem()
                {
                    MenuItemTypeId = 3,
                    Name = "Baked Beans",
                    Price = 0.50M,
                    Quantity = 0
                },
                new MenuItem()
                {
                    MenuItemTypeId = 4,
                    Name = "Water",
                    Price = 0.00M,
                    Quantity = 0
                },new MenuItem()
                {
                    MenuItemTypeId = 4,
                    Name = "Fountain",
                    Price = 0.75M,
                    Quantity = 0
                },new MenuItem()
                {
                    MenuItemTypeId = 4,
                    Name = "Beer",
                    Price = 3.00M,
                    Quantity = 0
                },new MenuItem()
                {
                    MenuItemTypeId = 5,
                    Name = "Chocolate Pie",
                    Price = 3.50M,
                    Quantity = 0
                },new MenuItem()
                {
                    MenuItemTypeId = 5,
                    Name = "Apple Pie",
                    Price = 3.50M,
                    Quantity = 0
                }
            };
            Db.SaveChanges();
            Db.MenuItems.AddRange(items);
        }

        private static void AddMenuItemTypes(AppDbContext Db)
        {
            var types = new List<MenuItemType>()
            {
                new MenuItemType()
                {
                    Id = 1,
                    Name = "Appetizer"
                },
                new MenuItemType()
                {
                    Id = 2,
                    Name = "Entree"
                },
                new MenuItemType()
                {
                    Id = 3,
                    Name = "Side"
                },
                new MenuItemType()
                {
                    Id = 4,
                    Name = "Drink"
                },
                new MenuItemType()
                {
                    Id = 5,
                    Name = "Dessert"
                }
            };
            Db.MenuItemTypes.AddRange(types);
            Db.SaveChanges();
        }


    }
}