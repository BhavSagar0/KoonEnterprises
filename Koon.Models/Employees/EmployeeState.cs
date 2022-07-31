using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Koon.Models.Employees
{
    public class EmployeeState
    {
        [Key]
        public int StateId { get; set; }
        [Required]
        [DataType("nvarchar(50)")]
        public string StateName { get; set; }
        [Required]
        [DataType("nvarchar(50)")]
        public string CapitalCity { get; set; }
    }
}
