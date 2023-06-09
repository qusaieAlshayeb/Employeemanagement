using Employeemanagement.Models;
using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;



namespace Employeemanagement.ViewModel
{
    public class AccountRegisterViewModel
    {
        [Required]
        [EmailAddress]
        [Remote(action:"IsEmailInUse",controller:"Account")]
        public string Email { get; set; }

        [Required]
        [DataType(DataType.Password)]
        public string Password { get; set; }

        [Required]
        [DataType(DataType.Password)]
        [Display(Name ="Confirm password")]
        [Compare("Password" ,ErrorMessage ="the password and confirm password are not the same")]
        public string confirmpassword { get; set; }


    }
}
