using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

//TODO: add in other validations for server number and password

namespace Restaurant.Models
{
    public class User
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "Server Number Required")]
        public int ServerNumber { get; set; }
        public string FullName { get; set; }
        [Required(ErrorMessage = "Password Required")]
        public string Password { get; set; }
        public bool Active { get; set; }
    }
}