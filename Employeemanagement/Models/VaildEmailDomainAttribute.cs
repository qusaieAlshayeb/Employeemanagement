using System.ComponentModel.DataAnnotations;

namespace Employeemanagement.Models
{
    public class VaildEmailDomainAttribute :ValidationAttribute
    {
        private readonly string allowedDomain;
        public VaildEmailDomainAttribute(string allowedDomain )
        {
            this.allowedDomain = allowedDomain;
        }

        public override bool IsValid(object? value)
        {
            return base.IsValid(value);
        }
    }
}

