using System;
using System.Collections.Generic;
using System.Linq;
using Restaurant.Models;
using Restaurant.ViewModels;

namespace Restaurant.Services
{
    public class OrderService
    {
        public static Order Build(List<MenuItem> orderedMenuItems, User server, int discount)
        {
            var subTotal = CashRegister.CalculateSubTotal(orderedMenuItems);
            var discountAmount = CashRegister.CalculateDiscount(discount, subTotal);
            var preTaxAmount = CashRegister.FormatAsCurrency(subTotal - discountAmount);
            var tax = CashRegister.CalculateTax(preTaxAmount);
            var total = CashRegister.FormatAsCurrency(preTaxAmount - tax);

            var order = new Order()
            {
                DateTime = DateTime.Now,
                SubTotal = subTotal,
                Server = server,
                Discount = discountAmount,
                PreTaxTotal = preTaxAmount >= 0.00M ? preTaxAmount : 0.00M,
                Tax = tax,
                Total = total
            };

            var savedOrder = SaveOrder(order);

            return savedOrder;
        }

        public static Order SaveOrder(Order order)
        {
            using (var Db = new AppDbContext())
            {
                var orderToSave = new Order()
                {
                    Id = order.Id,
                    DateTime = order.DateTime,
                    Discount = order.Discount,
                    PreTaxTotal = order.PreTaxTotal,
                    ServerId = order.Server.Id,
                    SubTotal = order.SubTotal,
                    Tax = order.Tax,
                    Total = order.Total
                };

                Db.Orders.Add(orderToSave);
                Db.SaveChanges();
                return orderToSave;
            }
        }

        public static List<Order> GetOrderHistory()
        {
            using (var Db = new AppDbContext())
            {
                return Db.Orders.Include("Server").ToList();
            }
        }

        public static void SaveOrderedItems(int orderId, List<MenuItem> orderedItems)
        {
            var items = orderedItems.Select(item => new OrderedMenuItem()
            {
                MenuItemId = item.Id,
                OrderId = orderId,
                Quantity = item.Quantity
            }).ToList();

            using (var Db = new AppDbContext())
            {
                Db.OrderedMenuItems.AddRange(items);
                Db.SaveChanges();
            }
        }

        public static Order GetOrderById(int id)
        {
            using (var Db = new AppDbContext())
            {
                return Db.Orders.Include("Server").Single(o => o.Id == id);
            }
        }

        public static List<MenuItem> GetOrderedItemsById(int id)
        {
            using (var Db = new AppDbContext())
            {
                var orderedItems = Db.OrderedMenuItems.Include("MenuItem").Where(i => i.OrderId == id).ToList();

                return orderedItems.Select(item => new MenuItem()
                {
                    Id = item.MenuItemId,
                    MenuItemTypeId = item.MenuItem.MenuItemTypeId,
                    MenuItemType = item.MenuItem.MenuItemType,
                    Name = item.MenuItem.Name,
                    Price = item.MenuItem.Price,
                    Quantity = item.Quantity
                }).ToList();
            }
        }
    }
}