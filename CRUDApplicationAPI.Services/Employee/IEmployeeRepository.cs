using CRUDApplicationAPI.Models;

namespace CRUDApplicationAPI.Services.Employee
{
    public interface IEmployeeRepository
    {
        public List<GetEmployeeModel> GetEmployees(int? Id);
        public int AddEmployee(ManageEmployeeModel EmployeeModel);
        public int UpdateEmployee(ManageEmployeeModel EmployeeModel, int Id);
        public int DeleteEmployee(int Id);
    }
}
