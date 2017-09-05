using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Restaurant.Models;

namespace Restaurant.ViewModels
{
    public class MenuItemFormViewModel
    {
        public List<MenuItemType> Types { get; set; }

        [Display(Name = "Type")]
        public int MenuItemTypeId { get; set; }

        [Required(ErrorMessage = "Name is required")]
        [StringLength(25, ErrorMessage = "Item name must be between 1 & 25 characters", MinimumLength = 1)]
        [RegularExpression("^[0-9A-Za-z ]+$", ErrorMessage = "Item name can only contain letters and numbers")]
        public string Name { get; set; }

        [Required(ErrorMessage = "Price is required")]
        [Range(0, 100, ErrorMessage = "Price must be between $0 & $100")]
        [RegularExpression("[0-9]*.?[0-9]{1,2}", ErrorMessage = "Price must be a number with up to 2 decimal places")]
        public decimal Price { get; set; }

        public int? Id { get; set; }
    }
}