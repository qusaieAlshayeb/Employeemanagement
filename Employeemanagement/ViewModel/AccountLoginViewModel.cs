using System.ComponentModel.DataAnnotations;

namespace Employeemanagement.ViewModel
{
    public class AccountLoginViewModel
    {
        [Required]
        [EmailAddress]
        public string Email { get; set; }


        [Required]
        [DataType(DataType.Password)]
        public string password { get; set; }

      
             
        [Display(Name ="Remember me")]
        public bool RememberMe { get; set; }











    }
}
