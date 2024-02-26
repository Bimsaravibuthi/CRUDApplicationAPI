using CRUDApplicationAPI.DataAccess;
using CRUDApplicationAPI.Models;
using System.Data.SqlClient;
using System.Data;

namespace CRUDApplicationAPI.Services.Employee
{
    public class EmployeeService : IEmployeeRepository
    {
        public List<GetEmployeeModel> GetEmployees(int? Id)
        {
            List<GetEmployeeModel> employeeModels = new();
            try
            {
                SqlCommand sqlCommand = new("sp_GetEmployees", DatabaseContext.GetSqlConnection())
                {
                    CommandType = CommandType.StoredProcedure
                };

                if (Id != null)
                {
                    sqlCommand.Parameters.AddWithValue("@Id", Id);
                }

                SqlDataAdapter adapter = new(sqlCommand);
                DataTable dataTable = new();
                adapter.Fill(dataTable);

                foreach (DataRow row in dataTable.Rows)
                {
                    GetEmployeeModel model = new()
                    {
                        Id = Convert.ToInt32(row["emp_id"]),
                        Firstname = row["emp_firstname"].ToString(),
                        Lastname = row["emp_lastname"].ToString(),
                        Email = row["emp_email"].ToString(),
                        Dateofbirth = DateTime.Parse(row["emp_date_of_birth"].ToString()),
                        Age = CalculateAge(DateTime.Parse(row["emp_date_of_birth"].ToString())),
                        Salary = Convert.ToDouble(row["emp_salary"]),
                        DepartmentId = row["dpt_id"] != DBNull.Value ? Convert.ToInt32(row["dpt_id"].ToString()) : 0,
                        Departmentcode = row["dpt_code"] != DBNull.Value ? row["dpt_code"].ToString() : "",
                        DepartmentName = row["dpt_name"] != DBNull.Value ? row["dpt_name"].ToString() : ""
                    };
                    employeeModels.Add(model);
                }
            }
            catch (Exception)
            {
                return [];
            }
            finally
            {
                DatabaseContext.Close();
            }
            return employeeModels;
        }
        public int AddEmployee(ManageEmployeeModel EmployeeModel)
        {
            int OPState = 0;
            try
            {
                SqlCommand sqlCommand = new("sp_AddEmployee", DatabaseContext.GetSqlConnection())
                {
                    CommandType = CommandType.StoredProcedure
                };

                sqlCommand.Parameters.AddWithValue("@Firstname", EmployeeModel.Firstname);
                sqlCommand.Parameters.AddWithValue("@Lastname", EmployeeModel.Lastname);
                sqlCommand.Parameters.AddWithValue("@Email", EmployeeModel.Email);
                sqlCommand.Parameters.AddWithValue("@Date_Of_Birth", EmployeeModel.Dateofbirth);
                sqlCommand.Parameters.AddWithValue("@Salary", EmployeeModel.Salary);
                sqlCommand.Parameters.AddWithValue("@Department", EmployeeModel.Department);

                OPState = sqlCommand.ExecuteNonQuery();
            }
            catch (Exception)
            {
                return OPState;
            }
            finally
            {
                DatabaseContext.Close();
            }
            return OPState;
        }
        public int UpdateEmployee(ManageEmployeeModel EmployeeModel, int Id)
        {
            int OPState = 0;
            try
            {
                SqlCommand sqlCommand = new("sp_UpdateEmployee", DatabaseContext.GetSqlConnection())
                {
                    CommandType = CommandType.StoredProcedure
                };

                sqlCommand.Parameters.AddWithValue("@Id", Id);
                sqlCommand.Parameters.AddWithValue("@Firstname", EmployeeModel.Firstname);
                sqlCommand.Parameters.AddWithValue("@Lastname", EmployeeModel.Lastname);
                sqlCommand.Parameters.AddWithValue("@Email", EmployeeModel.Email);
                sqlCommand.Parameters.AddWithValue("@Date_Of_Birth", EmployeeModel.Dateofbirth);
                sqlCommand.Parameters.AddWithValue("@Salary", EmployeeModel.Salary);
                sqlCommand.Parameters.AddWithValue("@Department", EmployeeModel.Department);

                OPState = sqlCommand.ExecuteNonQuery();
            }
            catch (Exception)
            {
                return OPState;
            }
            finally
            {
                DatabaseContext.Close();
            }
            return OPState;
        }
        public int DeleteEmployee(int Id)
        {
            int OPState = 0;
            try
            {
                SqlCommand sqlCommand = new("sp_DeleteEmployee", DatabaseContext.GetSqlConnection())
                {
                    CommandType = CommandType.StoredProcedure
                };

                sqlCommand.Parameters.AddWithValue("@Id", Id);

                OPState = sqlCommand.ExecuteNonQuery();
            }
            catch (Exception)
            {
                return OPState;
            }
            finally
            {
                DatabaseContext.Close();
            }
            return OPState;
        }
        private static int CalculateAge(DateTime birthDate)
        {
            DateTime currentDate = DateTime.Now.Date;          

            return currentDate.Year - birthDate.Year;
        }
    }
}
