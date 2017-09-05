using System.ComponentModel.DataAnnotations;
using Restaurant.Interfaces;

namespace Restaurant.Models
{
    public class Dessert : IMenuItem
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public decimal Price { get; set; }
        public bool OnMenu { get; set; }

        [RegularExpression("([0-9]*)", ErrorMessage = "Quantity must be a number")]
        public int Quantity { get; set; }
    }
}