using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Koon.Models.Employees
{
    public enum EmployeeMaritalStatus
    {
        [Display(Name = "Unmarried")]
        Unmarried,
        [Display(Name = "Married")]
        Married,
        [Display(Name = "Divorced")]
        Divorced,
        [Display(Name = "Widow")]
        Widow
    }
}
