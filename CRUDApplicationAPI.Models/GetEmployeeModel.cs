using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CRUDApplicationAPI.Models
{
    public class GetEmployeeModel
    {
        public int Id { get; set; }
        public string? Firstname { get; set; }
        public string? Lastname { get; set; }
        public string? Email { get; set; }
        public DateTime Dateofbirth { get; set; }
        public int Age { get; set; }
        public double Salary { get; set; }
        public int DepartmentId { get; set; }
        public string? Departmentcode { get; set; }
        public string? DepartmentName { get; set; }
    }
}
