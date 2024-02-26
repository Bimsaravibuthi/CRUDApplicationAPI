using CRUDApplicationAPI.DataAccess;
using CRUDApplicationAPI.Models;
using System.Data;
using System.Data.SqlClient;

namespace CRUDApplicationAPI.Services.Department
{
    public class DepartmentService : IDepartmentRepository
    {
        private readonly SqlConnection _connection;
        public DepartmentService()
        {
            _connection = DatabaseContext.GetSqlConnection();
        }
        public List<GetDepartmentModel> GetDepartments(int? Id)
        {
            List<GetDepartmentModel> departmentModels = new();
            try
            {
                SqlCommand sqlCommand = new("GetDepartments", _connection)
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
                    GetDepartmentModel model = new()
                    {
                        Id = Convert.ToInt32(row["ID"]),
                        Code = row["CODE"].ToString(),
                        Name = row["NAME"].ToString()
                    };
                    departmentModels.Add(model);
                }
            }
            catch (Exception)
            {
                return [];
            }
            finally
            {
                DatabaseContext.Dispose();
            }  
            return departmentModels;
        }
        public int AddDepartment(ManageDepartmentModel departmentModel)
        {
            int OPState = 0;
            try
            {
                SqlCommand sqlCommand = new("AddDepartment", _connection)
                {
                    CommandType = CommandType.StoredProcedure
                };

                sqlCommand.Parameters.AddWithValue("@Code", departmentModel.Code);
                sqlCommand.Parameters.AddWithValue("@Name", departmentModel.Name);

                OPState = sqlCommand.ExecuteNonQuery();
            }
            catch (Exception)
            {
                return OPState;
            }
            finally
            {
                DatabaseContext.Dispose();
            }

            return OPState;
        }
        public int UpdateDepartment(ManageDepartmentModel departmentModel, int Id)
        {
            int OPState = 0;
            try
            {
                SqlCommand sqlCommand = new("UpdateDepartment", _connection)
                {
                    CommandType = CommandType.StoredProcedure
                };

                sqlCommand.Parameters.AddWithValue("@Id", Id);
                sqlCommand.Parameters.AddWithValue("@Code", departmentModel.Code);
                sqlCommand.Parameters.AddWithValue("@Name", departmentModel.Name);

                OPState = sqlCommand.ExecuteNonQuery();
            }
            catch (Exception)
            {
                return OPState;
            }
            finally
            {
                DatabaseContext.Dispose();
            }

            return OPState;
        }
        public int DeleteDepartment(int Id)
        {
            int OPState = 0;
            try
            {
                SqlCommand sqlCommand = new("DeleteDepartment", _connection)
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
                DatabaseContext.Dispose();
            }
            return OPState;
        }
    }
}
