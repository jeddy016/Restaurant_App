using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Restaurant.ViewModels;

namespace Restaurant.Models
{
    public class Order
    {
        public int Id { get; set; }
        public decimal SubTotal { get; set; }
        public int Discount { get; set; }
        public decimal PreTaxTotal { get; set; }
        public decimal Tax { get; set; }
        public decimal Total { get; set; }
        public DateTime DateTime { get; set; }
        public User Server { get; set; }
    }
}