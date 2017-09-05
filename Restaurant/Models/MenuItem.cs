using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Restaurant.Models
{
    public class MenuItem
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public decimal Price { get; set; }
        public MenuItemType MenuItemType { get; set; }
        public int MenuItemTypeId { get; set; }

        [RegularExpression("([0-9]*)", ErrorMessage = "Quantity must be a number")]
        public int Quantity { get; set; }
    }
}