using CRUDApplicationAPI.DataAccess;
using CRUDApplicationAPI.Models;
using CRUDApplicationAPI.Shared;
using Dapper;
using System.Data;

namespace CRUDApplicationAPI.Dapper
{
    public class EmployeeService : IEmployeeRepository
    {
        public int AddEmployee(ManageEmployeeModel EmployeeModel)
        {
            int OPState = 0;

            try
            {
                var parameters = new
                {
                    EmployeeModel.Firstname,
                    EmployeeModel.Lastname,
                    EmployeeModel.Email,
                    Date_Of_Birth = EmployeeModel.Dateofbirth,
                    EmployeeModel.Salary,
                    EmployeeModel.Department
                };

                OPState = DatabaseContext.GetSqlConnection()
                    .Execute("sp_AddEmployee", parameters, commandType: CommandType.StoredProcedure);

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
        public int DeleteEmployee(int Id)
        {
            int OPState = 0;

            try
            {
                var parameters = new
                {
                    Id
                };

                OPState = DatabaseContext.GetSqlConnection()
                    .Execute("sp_DeleteEmployee", parameters, commandType: CommandType.StoredProcedure);

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
        public List<GetEmployeeModel> GetEmployees(int? Id)
        {
            try
            {
                var parameters = new
                {
                    Id
                };

                List<GetEmployeeModel> result = DatabaseContext.GetSqlConnection()
                    .Query<GetEmployeeModel>("sp_GetEmployees_dp", parameters, commandType: CommandType.StoredProcedure)
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
        public int UpdateEmployee(ManageEmployeeModel EmployeeModel, int Id)
        {
            int OPState = 0;

            try
            {
                var parameters = new
                {
                    Id,
                    EmployeeModel.Firstname,
                    EmployeeModel.Lastname,
                    EmployeeModel.Email,
                    Date_Of_Birth = EmployeeModel.Dateofbirth,
                    EmployeeModel.Salary,
                    EmployeeModel.Department
                };

                OPState = DatabaseContext.GetSqlConnection()
                    .Execute("sp_UpdateEmployee", parameters, commandType: CommandType.StoredProcedure);

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
