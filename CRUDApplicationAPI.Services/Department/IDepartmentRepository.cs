using CRUDApplicationAPI.Models;

namespace CRUDApplicationAPI.Services.Department
{
    public interface IDepartmentRepository
    {
        public List<DepartmentModel> GetDepartments(int? Id);
    }
}
