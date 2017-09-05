using System;

namespace Restaurant.Models
{
    public class Order
    {
        public int Id { get; set; }
        public DateTime DateTime { get; set; }
        public User Server { get; set; }
        public int ServerId { get; set; }
        public decimal SubTotal { get; set; }
        public decimal Discount { get; set; }
        public decimal PreTaxTotal { get; set; }
        public decimal Tax { get; set; }
        public decimal Total { get; set; }
    }
}