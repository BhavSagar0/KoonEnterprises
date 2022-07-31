using Koon.Models.Employees;
using Microsoft.AspNetCore.Http;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Koon.Models.ViewModels
{
    public class AddUpdateEmployeeViewModel
    {
        public bool? isSuccess { get; set; }
        public IFormFile imageFile { get; set; }
        [Required(ErrorMessage = "Image is required")]
        public string imageSrc { get; set; }
        public EmployeeDetails employee { get; set; }
        public IEnumerable<EmployeeCity> employeeCities { get; set; }
        public IEnumerable<EmployeeState> employeeStates { get; set; }
        public IEnumerable<EmployeeMaritalStatus> maritalStatus { get; set; }
        public IEnumerable<EmployeeDepartment> employeeDepartments { get; set; }
        public IEnumerable<EmployeeGender> employeeGenders { get; set; }
    }
}
