namespace CRUDApplicationAPI.Models
{
    public class EmployeeModel
    {
        public int Id { get; set; }
        public string? Firstname { get; set; }
        public string? Lastname { get; set;}
        public string? Email { get; set; }
        public DateOnly Dateofbirth { get; set; }
        public double Salary { get; set; }
        public EmployeeType Type { get; set; }
        public int Department { get; set; }
    }

    public enum EmployeeType
    {
        Normal,
        Admin
    }
}
