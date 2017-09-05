using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Restaurant.ViewModels
{
    public class EditUserFormViewModel
    {
        public int? Id { get; set; }

        [StringLength(25, ErrorMessage = "Names must be between 1 and 25 characters")]
        [RegularExpression("^[a-zA-Z]+$", ErrorMessage = "Names can only contain letters")]
        public string FirstName { get; set; }

        [StringLength(25, ErrorMessage = "Names must be between 1 and 25 characters")]
        [RegularExpression("^[a-zA-Z]+$", ErrorMessage = "Names can only contain letters")]
        public string LastName { get; set; }
    }
}