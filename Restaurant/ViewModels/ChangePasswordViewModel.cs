using System.ComponentModel.DataAnnotations;

namespace Restaurant.ViewModels
{
    public class ChangePasswordViewModel
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Password Required")]
        [StringLength(16, ErrorMessage = "Password must be between 4 & 16 characters", MinimumLength = 4)]
        [Display(Name = "New Password")]
        public string Password { get; set; }

        [Compare("Password", ErrorMessage = "Passwords do not match")]
        [Display(Name = "Confirm Password")]
        public string PasswordConfirm { get; set; }
    }
}