using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Restaurant.Models;

namespace Restaurant.ViewModels
{
    public class MenuViewModel
    {
        public List<MenuItem> Items { get; set; }
        public List<Discount> Discounts { get; set; }

        [Display(Name = "Discount: ")]
        public int SelectedDiscount { get; set; }
    }
}