using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Koon.Models.Employees
{
    public class EmployeeDepartment
    {

        [Column("DepartmentId")]
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Required(ErrorMessage = "Department ID is required")]
        [Display(Name = "Department ID")]
        public int DepartmentId { get; set; }

        [Column("DepartmentName")]
        [Display(Name = "Department Name")]
        [Required(ErrorMessage = "Department Name is required")]
        public string DepartmentName { get; set; }
    }
}
