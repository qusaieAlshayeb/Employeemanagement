using Microsoft.AspNetCore.Mvc;

namespace Employeemanagement.Controllers
{
    public class EmployeeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
