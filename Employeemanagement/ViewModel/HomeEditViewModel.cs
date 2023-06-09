using Employeemanagement.Models;
using System.ComponentModel.DataAnnotations;

namespace Employeemanagement.ViewModel
{
    public class HomeEditViewModel :HomeCreateViewModel
    {
        public int Id { get; set; }
        public string?  ExistingPhotoPath { get; set; }
        




    }
}
