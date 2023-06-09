using System.ComponentModel.DataAnnotations;

namespace Employeemanagement.Models { 

    public class Employee
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "the name is required")]
        [MinLength(3, ErrorMessage = "the Name must be at least 3 character.")]
        [MaxLength(50)]
        public string Name { get; set; }
        [Required]
        [RegularExpression("^[\\w-\\.]+@([\\w-]+\\.)+[\\w-]{2,3}$", ErrorMessage = "invaild Email Format")]
        [Display(Name = "Office Email")]
        public string Email { get; set; }
        public Dept Department { get; set; }

        public string Photopath { get; set; } = string.Empty;

    }
}
