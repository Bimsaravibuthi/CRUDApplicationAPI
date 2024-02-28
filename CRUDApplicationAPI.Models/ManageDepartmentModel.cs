using System.ComponentModel.DataAnnotations;

namespace CRUDApplicationAPI.Models
{
    public class ManageDepartmentModel
    {
        [Required(ErrorMessage ="Code is required")]
        [MaxLength(2, ErrorMessage ="Allowed only 2 characters")]
        public string? Code { get; set; }
        [Required(ErrorMessage = "Name is required")]
        [MaxLength(30, ErrorMessage = "Allowed only 30 characters")]
        public string? Name { get; set; }
    }
}
