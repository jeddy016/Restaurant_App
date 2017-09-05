using System;
using System.Collections.Generic;
using System.Linq;
using Restaurant.Models;

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

            Order order = new Order()
            {
                DateTime = DateTime.Now,
                Server = server,
                ServerId = server.Id,
                SubTotal = subTotal,
                Discount = discountAmount,
                PreTaxTotal = preTaxAmount >= 0.00M ? preTaxAmount : 0.00M,
                Tax = tax,
                Total = total
            };

            return order;
        }

        public static void Save(Order order)
        {
            using (var Db = new AppDbContext())
            {
                Db.Orders.Add(order);
                Db.SaveChanges();
            }
        }

        public static List<Order> GetOrderHistory()
        {
            using (var Db = new AppDbContext())
            {
                return Db.Orders.Include("Server").ToList();
            }
        }
    }
}