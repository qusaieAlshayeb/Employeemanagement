using Microsoft.AspNetCore.Identity;

namespace Employeemanagement.Models
{
    public class ApplicationUser :IdentityUser
    {
        public string Country { get; set; }


    }
}
