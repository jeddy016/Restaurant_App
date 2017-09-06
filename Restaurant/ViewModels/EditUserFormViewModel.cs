using System.ComponentModel.DataAnnotations;

namespace Restaurant.ViewModels
{
    public class EditUserFormViewModel
    {
        public int? Id { get; set; }

        [StringLength(25, ErrorMessage = "Names must be between 1 and 25 characters")]
        [RegularExpression("^[a-zA-Z]+$", ErrorMessage = "Names can only contain letters")]
        [Display(Name = "First Name")]
        public string FirstName { get; set; }

        [StringLength(25, ErrorMessage = "Names must be between 1 and 25 characters")]
        [RegularExpression("^[a-zA-Z]+$", ErrorMessage = "Names can only contain letters")]
        [Display(Name = "Last Name")]
        public string LastName { get; set; }
    }
}