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
        public List<DepartmentModel> GetDepartments(int? Id)
        {
            List<DepartmentModel> departmentModels = new();
            try
            {
                SqlCommand sqlCommand = new("GetDepartments", _database.GetSqlConnection())
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
                    DepartmentModel model = new()
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
                _database.Dispose();
            }  
            return departmentModels;
        }
        public int AddDepartment(DepartmentModel departmentModel)
        {
            int OPState = 0;
            try
            {
                SqlCommand sqlCommand = new("AddDepartment", _database.GetSqlConnection())
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
        public int UpdateDepartment(DepartmentModel departmentModel, int Id)
        {
            int OPState = 0;
            try
            {
                SqlCommand sqlCommand = new("UpdateDepartment", _database.GetSqlConnection())
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
                SqlCommand sqlCommand = new("DeleteDepartment", _database.GetSqlConnection())
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
