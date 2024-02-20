using CRUDApplicationAPI.Models;

namespace CRUDApplicationAPI.Services.Department
{
    public interface IDepartmentRepository
    {
        public List<DepartmentModel> GetDepartments(int? Id);
        public int AddDepartment(DepartmentModel departmentModel);
        public int UpdateDepartment(DepartmentModel departmentModel, int Id);
        public int DeleteDepartment(int Id);
    }
}
