namespace Employeemanagement.Models
{
    public class MockEmployeeRepository : IEmployeeRepository


    {

        private List<Employee> _employeeList;


        public MockEmployeeRepository()
        {
            _employeeList = new List<Employee>() {
            new Employee() { Id = 1, Name = "ahmed", Department = Dept.IT, Email = "yaeMiko@gmail.com" },
            new Employee() { Id = 2, Name = "ali", Department = Dept.IT, Email = "nilou@gmail.com " },
            new Employee() { Id = 3, Name = "omer", Department =Dept.payroll, Email = "kokomi@gmail.com" },
            new Employee() { Id = 4, Name = "john ", Department = Dept.HR, Email = "nahida@hmail.com" }




             };






        }

        public Employee AddEmployee(Employee employee)
        {
            throw new NotImplementedException();
        }

        public Employee DeleteEmployee(int id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Employee> GetAllEmployee()
        {
            return _employeeList;




        }

        public Employee UpdateEmployee(Employee employeeChanges)
        {
            throw new NotImplementedException();
        }

        Employee IEmployeeRepository.GetEmployee(int id)
        {
            return _employeeList.FirstOrDefault(e => e.Id == id);

        }
    }
}
