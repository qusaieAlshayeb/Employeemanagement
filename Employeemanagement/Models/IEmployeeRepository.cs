namespace Employeemanagement.Models
{
    public interface IEmployeeRepository
    {

        Employee  GetEmployee  (int id);
        
      IEnumerable<Employee> GetAllEmployee ();

        Employee AddEmployee(Employee employee);



        Employee UpdateEmployee(Employee employeeChanges);
        Employee DeleteEmployee(int id);

    }
}
