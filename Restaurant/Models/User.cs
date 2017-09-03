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
        public int ServerNumber { get; set; }

        public string FullName { get; set; }

        [Required(ErrorMessage = "Password Required")]
        public string Password { get; set; }

        public bool Active { get; set; }
    }
}