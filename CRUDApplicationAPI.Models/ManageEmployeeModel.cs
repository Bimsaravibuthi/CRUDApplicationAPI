using System.ComponentModel.DataAnnotations;

namespace CRUDApplicationAPI.Models
{
    public class ManageEmployeeModel
    {
        [Required(ErrorMessage ="Firstname is required")]
        [MaxLength(20, ErrorMessage = "Allowed only 20 characters")]
        public string? Firstname { get; set; }
        [Required(ErrorMessage = "Lastname is required")]
        [MaxLength(20, ErrorMessage = "Allowed only 20 characters")]
        public string? Lastname { get; set;}
        [Required(ErrorMessage = "Email address is required")]
        [EmailAddress(ErrorMessage ="Email address is not valid")]
        [MaxLength(30, ErrorMessage = "Allowed only 30 characters")]
        public string? Email { get; set; }
        [Required(ErrorMessage ="Date of birth is required")]
        public DateTime Dateofbirth { get; set; }
        public double Salary { get; set; }
        [Required(ErrorMessage ="Department ID is required")]
        public int Department { get; set; }
    }
}
