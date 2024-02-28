using CRUDApplicationAPI.DataAccess;
using CRUDApplicationAPI.Models;
using CRUDApplicationAPI.Shared;
using Dapper;
using System.Data;

namespace CRUDApplicationAPI.Dapper
{
    public class DepartmentService : IDepartmentRepository
    {
        public int AddDepartment(ManageDepartmentModel departmentModel)
        {
            int OPState = 0;

            try
            {
                var parameters = new
                {
                    departmentModel.Code,
                    departmentModel.Name,
                };

               OPState = DatabaseContext.GetSqlConnection()
                    .Execute("sp_AddDepartment", parameters, commandType: CommandType.StoredProcedure);

                return OPState;
            }
            catch
            {
                return OPState;
            }
            finally 
            {
                DatabaseContext.Close();
            }
        }
        public int DeleteDepartment(int Id)
        {
            int OPState = 0;

            try
            {
                var parameters = new
                {
                    Id
                };

                OPState = DatabaseContext.GetSqlConnection()
                    .Execute("sp_DeleteDepartment", parameters, commandType: CommandType.StoredProcedure);

                return OPState;
            }
            catch
            {
                return OPState;
            }
            finally
            {
                DatabaseContext.Close();
            }
        }
        public List<GetDepartmentModel> GetDepartments(int? Id)
        {
            try
            {
                var parameters = new { Id };

                List<GetDepartmentModel> result = DatabaseContext.GetSqlConnection()
                    .Query<GetDepartmentModel>("sp_GetDepartments_dp", parameters, commandType: CommandType.StoredProcedure)
                    .ToList();

                return result;
            }
            catch (Exception)
            {
                return [];
            }
            finally
            {
                DatabaseContext.Close();
            }
        }
        public int UpdateDepartment(ManageDepartmentModel departmentModel, int Id)
        {
            int OPState = 0;

            try
            {
                var parameters = new
                {
                    Id,
                    departmentModel.Code,
                    departmentModel.Name,
                };

                OPState = DatabaseContext.GetSqlConnection()
                    .Execute("sp_UpdateDepartment", parameters, commandType: CommandType.StoredProcedure);
                
                return OPState;
            }
            catch (Exception)
            {
                return OPState;
            }
            finally
            {
                DatabaseContext.Close();
            }
        }
    }
}
