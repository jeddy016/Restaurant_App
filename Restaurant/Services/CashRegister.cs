using System;
using System.Collections.Generic;
using System.Linq;
using Restaurant.Interfaces;
using Restaurant.Models;

namespace Restaurant.Services
{
    public class CashRegister
    {
        public static decimal CalculateSubTotal(List<IMenuItem> menu)
        {
            ;
            var subTotal = 0.00M;

            foreach (var menuItem in menu)
            {
                subTotal += menuItem.Price * menuItem.Quantity;
            }

            return subTotal;
        }

        public static decimal CalculateDiscount(int discount, decimal subTotal)
        {
            return FormatAsCurrency((discount / 100M) * subTotal);
        }

        public static decimal CalculateTax(decimal preTaxAmount)
        {
            decimal taxRate = GetTaxes().Sum(t => t.Percentage) / 100M;

            return FormatAsCurrency(preTaxAmount * taxRate);
        }

        public static decimal FormatAsCurrency(decimal input)
        {
            return Decimal.Round(input, 2, MidpointRounding.AwayFromZero);
        }

        public static List<Discount> GetDiscounts()
        {
            using (AppDbContext Db = new AppDbContext())
            {
                return Db.Discounts.ToList();
            }
        }

        public static List<Tax> GetTaxes()
        {
            using (AppDbContext Db = new AppDbContext())
            {
                return Db.Taxes.ToList();
            }
        }

    }
}
