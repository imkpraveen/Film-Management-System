using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace FilmManagementSystemMVC.Models
{
    public class Login
    {
        [Required]
        [EmailAddress(ErrorMessage = "Enter Email in correct format")]
        public String Email { get; set; }
        [Required]
        [DataType(DataType.Password)]
        public string Password { get; set; }
    }
}