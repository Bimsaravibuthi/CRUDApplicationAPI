using System.Data.SqlClient;

namespace CRUDApplicationAPI.DataAccess
{
    public class DatabaseContext
    {
        private const string ConnectionString = "Data Source=DESKTOP-TH5C59L\\SQLEXPRESS;Initial Catalog=CRUDApplication;Integrated Security=True;";
        private readonly SqlConnection _connection;

        public DatabaseContext()
        {
            _connection = new SqlConnection(ConnectionString);
        }
        public SqlConnection GetSqlConnection()
        {
            if (_connection.State != System.Data.ConnectionState.Open)
            {
                _connection.Open();
            }
            return _connection;
        }
    }
}
