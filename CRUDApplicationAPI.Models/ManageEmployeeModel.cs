namespace CRUDApplicationAPI.Models
{
    public class ManageEmployeeModel
    {
        public int Id { get; set; }
        public string? Firstname { get; set; }
        public string? Lastname { get; set;}
        public string? Email { get; set; }
        public DateTime Dateofbirth { get; set; }
        public int Age { get; set; }
        public double Salary { get; set; }
        public int Department { get; set; }
    }
}
