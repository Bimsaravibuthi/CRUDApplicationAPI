using System.ComponentModel.DataAnnotations;

namespace CRUDApplicationAPI.Models
{
    public class ManageEmployeeModel
    {
        [Required(ErrorMessage ="Firstname is required")]
        public string? Firstname { get; set; }
        [Required(ErrorMessage = "Lastname is required")]
        public string? Lastname { get; set;}
        [Required(ErrorMessage = "Email address is required")]
        [EmailAddress(ErrorMessage ="Email address is not valid")]
        public string? Email { get; set; }
        [Required(ErrorMessage ="Date of birth is required")]
        public DateTime Dateofbirth { get; set; }
        public double Salary { get; set; }
        [Required(ErrorMessage ="Department ID is required")]
        public int Department { get; set; }
    }
}
