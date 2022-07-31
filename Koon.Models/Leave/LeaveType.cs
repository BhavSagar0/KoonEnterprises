using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Koon.Models.Leave
{
    public enum LeaveType
    {
        [Display(Name = "Casual Leave")]
        CasualLeave,
        [Display(Name = "Sick Leave")]
        SickLeave,
        [Display(Name = "Earned Leave")]
        EarnedLeave,
        [Display(Name = "Compensatory Leave")]
        CompensatoryLeave,
        [Display(Name = "Maternity Leave")]
        MaternityLeave,
        [Display(Name = "Present/Biometric Missout")]
        PresentBiometricMissout,
        [Display(Name = "Working From Home")]
        WorkingFromHome,
        [Display(Name = "On Office Duty")]
        OnOfficeDuty,
        [Display(Name = "Leave Cancellation Request")]
        LeaveCancellationRequest,
        [Display(Name = "Credit Compensatory Leave")]
        CreditCompensatoryLeave,
        [Display(Name = "Client Holiday")]
        ClientHoliday,
        [Display(Name = "Covid Leave")]
        CovidLeave
    }
}
