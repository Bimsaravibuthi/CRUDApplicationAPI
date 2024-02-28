using CRUDApplicationAPI.Models;

namespace CRUDApplicationAPI.Shared
{
    public interface IDepartmentRepository
    {
        public List<GetDepartmentModel> GetDepartments(int? Id);
        public int AddDepartment(ManageDepartmentModel departmentModel);
        public int UpdateDepartment(ManageDepartmentModel departmentModel, int Id);
        public int DeleteDepartment(int Id);
    }
}
