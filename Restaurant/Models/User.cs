using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

//TODO: add other validations for server number, password, full name

namespace Restaurant.Models
{
    public class User
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Server Number Required")]
        [Display(Name = "Server Number")]
        [StringLength(4, ErrorMessage = "Server Number must be a 4 digit number", MinimumLength = 4)]
        [RegularExpression("^[0-9]*$", ErrorMessage = "Server Number Must be a 4 digit number")]
        public string ServerNumber { get; set; }

        public string FullName { get; set; }

        [Required(ErrorMessage = "Password Required")]
        [StringLength(16, ErrorMessage = "Password must be between 8 & 16 characters", MinimumLength = 4)]
        public string Password { get; set; }

        public bool Active { get; set; }
    }
}