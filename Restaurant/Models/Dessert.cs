using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Restaurant.Models
{
    public class Dessert
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public decimal Price { get; set; }
        public bool onMenu { get; set; }
        [RegularExpression("([1-9][0-9]*)", ErrorMessage = "Quantity must be a number")]
        public int Quantity { get; set; }
    }
}