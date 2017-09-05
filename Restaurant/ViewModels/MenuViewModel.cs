using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Restaurant.Models;

namespace Restaurant.ViewModels
{
    public class MenuViewModel
    {
        //public List<Entree> Entrees { get; set; }
        //public List<Appetizer> Appetizers { get; set; }
        //public List<Side> Sides { get; set; }
        //public List<Dessert> Desserts { get; set; }
        //public List<Drink> Drinks { get; set; }
        public List<MenuItem> Items { get; set; }
        public List<Discount> Discounts { get; set; }

        [Display(Name = "Discount: ")]
        public int SelectedDiscount { get; set; }
    }
}