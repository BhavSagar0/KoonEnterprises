using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Koon.Models.Employees
{
    public class EmployeeDetails
    {

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int EmployeeId { get; set; }
        [Required]
        [StringLength(30)]
        [Display(Name = "First Name")]
        public string FirstName { get; set; }
        [Required]
        [StringLength(30)]
        [Display(Name = "Last Name")]
        public string LastName { get; set; }

        [Display(Name = "Email address")]
        [Required(ErrorMessage = "The email address is required")]
        [EmailAddress(ErrorMessage = "Invalid Email Address")]
        public string Email { get; set; }
        [Required(ErrorMessage = "You must provide a phone number")]
        [Display(Name = "Phone Number")]
        [DataType(DataType.PhoneNumber)]
        [RegularExpression(@"^\(?([0-9]{3})\)?[-. ]?([0-9]{3})[-. ]?([0-9]{4})$", ErrorMessage = "Not a valid phone number")]
        public string Phone { get; set; }

        [Required(ErrorMessage = "Please select a department")]
        [Range(1, int.MaxValue, ErrorMessage = "Please select a department")]
        [Display(Name = "Department")]
        public int Department { get; set; }
        [Range((int)EmployeeGender.Male, (int)EmployeeGender.Others, ErrorMessage = "Gender is required")]
        public EmployeeGender Gender { get; set; }
        [Required]
        [Display(Name = "Marital Status")]
        public EmployeeMaritalStatus MaritalStatus { get; set; }
        [Required(ErrorMessage = "Please select a state")]
        [Range(1,int.MaxValue, ErrorMessage ="Please select a state")]
        [Display(Name = "State")]
        public int StateId { get; set; }
        [Required(ErrorMessage = "Please select a city")]
        [Range(1, double.MaxValue,ErrorMessage = "Please select a city")]
        [Display(Name = "City")]
        public int CityId { get; set; }
        [Display(Name = "Upload Image")]
        public byte[] Image { get; set; }
    }
}