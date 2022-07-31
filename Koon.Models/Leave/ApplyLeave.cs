using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Koon.Models.Leave
{
   public class ApplyLeave
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int LeaveId { get; set; }
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Display(Name = "Name")]
        public string Name { get; set; }
        [DataType(DataType.Date)]
        [Display(Name = "From Date")]
        public DateTime FromDate { get; set; }
        [Required(ErrorMessage = "To Date  is required")]
        [DataType(DataType.Date)]
        [Display(Name = "To Date")]
        public DateTime ToDate { get; set; }
        public int NumberOfDays
        {
            get
            {
                if (ToDate != null && FromDate != null)
                {
                    return Convert.ToInt32((ToDate - FromDate).TotalDays + 1);
                }
                return 0;
            }
        }
        public LeaveType LeaveType { get; set; }
        public LeaveCategory LeaveCategory { get; set; }
        [Required(ErrorMessage = "Reason is required")]
        public string ReasonForLeave { get; set; }
        public string Email { get; set; }
        public int EmployeeId { get; set; }

    }
}
