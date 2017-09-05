using System.ComponentModel.DataAnnotations;

namespace Restaurant.Models
{
    public class User
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Server Number Required")]
        [Display(Name = "Server Number")]
        [StringLength(4, ErrorMessage = "Server Number must be a 4 digit number", MinimumLength = 4)]
        [RegularExpression("^[0-9]*$", ErrorMessage = "Server Number must be a 4 digit number")]
        public string ServerNumber { get; set; }

        [StringLength(25, ErrorMessage = "Names must be between 1 and 25 characters")]
        [RegularExpression("^[a-zA-Z]+$", ErrorMessage = "Names can only contain letters")]
        public string FirstName { get; set; }

        [StringLength(25, ErrorMessage = "Names must be between 1 and 25 characters")]
        [RegularExpression("^[a-zA-Z]+$", ErrorMessage = "Names can only contain letters")]
        public string LastName { get; set; }

        public string FullName => FirstName + " " + LastName;

        [Required(ErrorMessage = "Password Required")]
        [StringLength(16, ErrorMessage = "Password must be between 4 & 16 characters", MinimumLength = 4)]
        public string Password { get; set; }

        public bool Active { get; set; }
    }
}