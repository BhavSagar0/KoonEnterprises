using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Koon.Models.Leave
{
    public enum LeaveCategory
    {
        [Display(Name ="Full Day")]
        FullDay,
        [Display(Name = "Half Day")]
        HalfDay
    }
}
