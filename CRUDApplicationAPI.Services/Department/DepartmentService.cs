using CRUDApplicationAPI.DataAccess;
using CRUDApplicationAPI.Models;
using System.Data;
using System.Data.SqlClient;

namespace CRUDApplicationAPI.Services.Department
{
    public class DepartmentService : IDepartmentRepository
    {
        private readonly DatabaseContext _database;
        public DepartmentService()
        {
            _database = new();
        }
        public List<GetDepartmentModel> GetDepartments(int? Id)
        {
            List<GetDepartmentModel> departmentModels = new();
            try
            {
                SqlCommand sqlCommand = new("sp_GetDepartments", _database.GetSqlConnection())
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
                        Id = Convert.ToInt32(row["dpt_id"]),
                        Code = row["dpt_code"].ToString(),
                        Name = row["dpt_name"].ToString()
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
                _database.Dispose();
            }  
            return departmentModels;
        }
        public int AddDepartment(ManageDepartmentModel departmentModel)
        {
            int OPState = 0;
            try
            {
                SqlCommand sqlCommand = new("sp_AddDepartment", _database.GetSqlConnection())
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
                _database.Dispose();
            }

            return OPState;
        }
        public int UpdateDepartment(ManageDepartmentModel departmentModel, int Id)
        {
            int OPState = 0;
            try
            {
                SqlCommand sqlCommand = new("sp_UpdateDepartment", _database.GetSqlConnection())
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
                _database.Dispose();
            }

            return OPState;
        }
        public int DeleteDepartment(int Id)
        {
            int OPState = 0;
            try
            {
                SqlCommand sqlCommand = new("sp_DeleteDepartment", _database.GetSqlConnection())
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
    }
}
