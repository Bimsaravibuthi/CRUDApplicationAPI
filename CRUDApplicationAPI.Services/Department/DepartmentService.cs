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
            SqlCommand sqlCommand = new("SELECT * FROM tbl_department", _database.GetSqlConnection());
            SqlDataAdapter adapter = new(sqlCommand);
            DataTable dataTable = new();
            adapter.Fill(dataTable);

            List<DepartmentModel> departmentModels = new();

            foreach (DataRow row in dataTable.Rows)
            {
                DepartmentModel model = new()
                {
                    Id = Convert.ToInt32(row["ID"]),
                    Code = row["CODE"].ToString(),
                    Name = row["Name"].ToString()
                };
                departmentModels.Add(model);
            }

            return departmentModels;
        }
    }
}
