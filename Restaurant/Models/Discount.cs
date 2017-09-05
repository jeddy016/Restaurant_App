using System.ComponentModel.DataAnnotations;

namespace Restaurant.Models
{
    public class Discount
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Discount name required")]
        [StringLength(25, ErrorMessage = "Discount name must be between 1 and 25 characters", MinimumLength = 1)]
        public string Name { get; set; }

        [Required(ErrorMessage = "Discount percentage required")]
        [Range(0, 100, ErrorMessage = "Discount percentage must be a number from 1 to 100")]
        public int Percentage { get; set; }
    }
}