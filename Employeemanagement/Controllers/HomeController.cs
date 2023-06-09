using Employeemanagement.Models;
using Employeemanagement.ViewModel;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ViewEngines;

namespace Employeemanagement.Controllers
{
    public class HomeController : Controller
    {
        private readonly IEmployeeRepository _employeeRepository;
        private readonly IWebHostEnvironment _webHostEnvironment;
        public HomeController(IEmployeeRepository employeeRepository, IWebHostEnvironment webHostEnvironment)
        {

            this._employeeRepository = employeeRepository;
            _webHostEnvironment = webHostEnvironment;
        }

        public ViewResult Index()
        {


            var ALLemployees = _employeeRepository.GetAllEmployee();
            return View(ALLemployees);

        }








        [Route("Home/Details/{id?}")]
        public ViewResult Details(int? id)
        {
            HomeDetailsViewModel homeDetailsViewModel = new HomeDetailsViewModel()
            {
                employee = _employeeRepository.GetEmployee(id ?? 1),

                pageTitle = "Employee Details",
            };






            return View(homeDetailsViewModel);

        }


        [HttpGet]
        public ViewResult Create()
        {

            return View();
        }


        [HttpPost]
        public IActionResult Create(HomeCreateViewModel model)
        {
            if (ModelState.IsValid)
            {
                string uniqueFileName = processUploadFile(model);
                Employee employee = new Employee
                {
                    Name = model.Name,
                    Email = model.Email,
                    Department = model.Department,
                    Photopath = uniqueFileName


                };
                _employeeRepository.AddEmployee(employee);
                return RedirectToAction("Details", new { id = employee.Id });

            }
            return View(model);


        }

        private string processUploadFile(HomeCreateViewModel model)
        {
            string uniqueFileName = null;
            if (model.Photo != null)
            {
                string uploadFloader = Path.Combine(_webHostEnvironment.WebRootPath, "images");
                uniqueFileName = Guid.NewGuid().ToString() + "_" + model.Photo.FileName;
                string filepath = Path.Combine(uploadFloader, uniqueFileName);
                model.Photo.CopyTo(new FileStream(filepath, FileMode.Create));
            }

            return uniqueFileName;
        }

        public ViewResult PageEmployee()
        {
            return View();
        }



        [HttpGet]
        public ViewResult Edit(int id)
        {
            Employee employee = _employeeRepository.GetEmployee(id);

            HomeEditViewModel homeEditViewModel = new HomeEditViewModel
            {
                Id= id,
                Name = employee.Name,
                Email = employee.Email,
                Department = employee.Department,
                ExistingPhotoPath =employee.Photopath
                
            };
            return View(homeEditViewModel);
        }

         [HttpPost]
        public IActionResult Edit(HomeEditViewModel model)
        {
           
            if (ModelState.IsValid)
            { 
                Employee employee = _employeeRepository.GetEmployee(model.Id);
                employee.Name = model.Name;
                employee.Email = model.Email;
                employee.Department = model.Department;

                if (model.Photo != null)
                {
                    if (model.ExistingPhotoPath!= null)
                    {
                        string filepath =Path.Combine(_webHostEnvironment.WebRootPath,"images",model.ExistingPhotoPath);
                        System.IO.File.Delete(filepath);
                    }
                    employee.Photopath = processUploadFile(model);
                }
                Employee emp = _employeeRepository.UpdateEmployee(employee);
               
                  return RedirectToAction("index");
            }
            return View(model);
           
        }



    }
}