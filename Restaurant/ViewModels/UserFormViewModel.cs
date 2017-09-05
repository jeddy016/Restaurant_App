using System.ComponentModel.DataAnnotations;

namespace Restaurant.ViewModels
{
    public class NewUserFormViewModel
    {
        public int? Id { get; set; }

        [StringLength(25, ErrorMessage = "Names must be between 1 and 25 characters")]
        [RegularExpression("^[a-zA-Z]+$", ErrorMessage = "Names can only contain letters")]
        public string FirstName { get; set; }

        [StringLength(25, ErrorMessage = "Names must be between 1 and 25 characters")]
        [RegularExpression("^[a-zA-Z]+$", ErrorMessage = "Names can only contain letters")]
        public string LastName { get; set; }

        [Required(ErrorMessage = "Password Required")]
        [StringLength(16, ErrorMessage = "Password must be between 4 & 16 characters", MinimumLength = 4)]
        public string Password { get; set; }

        [Compare("Password", ErrorMessage = "Passwords do not match")]
        [Display(Name = "Confirm Password")]
        public string PasswordConfirm { get; set; }
    }
}