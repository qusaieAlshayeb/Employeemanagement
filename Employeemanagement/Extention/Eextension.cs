using Employeemanagement.Models;
using Microsoft.EntityFrameworkCore;

namespace Employeemanagement.Extention
{

    namespace Employeemanagement.Eextension
    {
        public static class ModelBuilderExtention
        {
            public static void SeeDataEmployee(this ModelBuilder modelBuilder)
            {
                modelBuilder.Entity<Employee>().HasData(
                    new Employee
                    {
                        Id = 1,
                        Name = "qusai",
                        Email = "carbig1234@gamil.com",
                        Department = Dept.IT

                    }
                    );


            }


        }
    }   }
