using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace FilmManagementSystemMVC.Models
{
    public class Registration
    {
        [Required(ErrorMessage = "FirstName is mandatory.")]
        public string FirstName { get; set; }
        [Required(ErrorMessage = "LastName is mandatory.")]
        public string LastName { get; set; }
        [Required(ErrorMessage = "Name is mandatory.")]
        [EmailAddress(ErrorMessage = "Enter Email in correct format")]
        public string Email { get; set; }
        [Required]
        [DataType(DataType.Password)]
        public string Password { get; set; }
        [Required]
        [DataType(DataType.Password)]
        [Compare("Password", ErrorMessage = "Password doesn't match Confirm password")]
        public string ConfirmPassword { get; set; }
    }
}