using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Koon.Models.Employees
{
    public class EmployeeCity
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int CityId { get; set; }

        [Required(ErrorMessage = "City name  is required")]
        [StringLength(40, ErrorMessage = "String lenght is exceeding than limit ")]
        public string CityName { get; set; }

        [Required(ErrorMessage = "StateId  is required")]
        public int StateId { get; set; }
    }
}
