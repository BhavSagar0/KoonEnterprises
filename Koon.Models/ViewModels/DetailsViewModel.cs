using Koon.Models.Employees;
using System;
using System.Collections.Generic;
using System.Text;

namespace Koon.Models.ViewModels
{
    public class DetailsViewModel
    {
        public EmployeeDetails employeeDetails { get; set; }
        public string imageSrc { get; set; }
        public string StateName { get; set; }
        public string CityName { get; set; }
    }
}
