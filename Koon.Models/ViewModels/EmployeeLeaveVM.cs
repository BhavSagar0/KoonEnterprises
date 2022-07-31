using Koon.Models.Employees;
using Koon.Models.Leave;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Koon.Models.ViewModels
{
    public class EmployeeLeaveVM
    {
        public string employeeName { get; set; }
        public int employeeId { get; set; }
        public string employeeEmail { get; set; }
    }
}
