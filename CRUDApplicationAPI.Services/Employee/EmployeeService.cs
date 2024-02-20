using CRUDApplicationAPI.DataAccess;
using CRUDApplicationAPI.Models;
using System.Data.SqlClient;
using System.Data;

namespace CRUDApplicationAPI.Services.Employee
{
    public class EmployeeService : IEmployeeRepository
    {
        private readonly DatabaseContext _database;
        public EmployeeService()
        {
            _database = new();
        }
        public List<GetEmployeeModel> GetEmployees(int? Id)
        {
            List<GetEmployeeModel> employeeModels = new();
            try
            {
                SqlCommand sqlCommand = new("GetEmployees", _database.GetSqlConnection())
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
                        Id = Convert.ToInt32(row["ID"]),
                        Firstname = row["FIRSTNAME"].ToString(),
                        Lastname = row["LASTNAME"].ToString(),
                        Email = row["EMAIL"].ToString(),
                        Dateofbirth = DateTime.Parse(row["DATE_OF_BIRTH"].ToString()),
                        Age = CalculateAge(DateTime.Parse(row["DATE_OF_BIRTH"].ToString())),
                        Salary = Convert.ToDouble(row["SALARY"]),
                        DepartmentId = Convert.ToInt32(row["DPT_ID"]),
                        Departmentcode = row["DPT_CODE"].ToString(),
                        DepartmentName = row["DPT_NAME"].ToString()
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
                _database.Dispose();
            }
            return employeeModels;
        }
        public int AddEmployee(ManageEmployeeModel EmployeeModel)
        {
            int OPState = 0;
            try
            {
                SqlCommand sqlCommand = new("AddEmployee", _database.GetSqlConnection())
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
                _database.Dispose();
            }
            return OPState;
        }
        public int UpdateEmployee(ManageEmployeeModel EmployeeModel, int Id)
        {
            int OPState = 0;
            try
            {
                SqlCommand sqlCommand = new("UpdateEmployee", _database.GetSqlConnection())
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
                _database.Dispose();
            }
            return OPState;
        }
        public int DeleteEmployee(int Id)
        {
            int OPState = 0;
            try
            {
                SqlCommand sqlCommand = new("DeleteEmployee", _database.GetSqlConnection())
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
                _database.Dispose();
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
