using System.ComponentModel.DataAnnotations;

namespace CRUDApplicationAPI.Models
{
    public class ManageDepartmentModel
    {
        [Required(ErrorMessage ="Code is required")]
        public string? Code { get; set; }
        [Required(ErrorMessage = "Name is required")]
        public string? Name { get; set; }
    }
}
