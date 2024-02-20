using System.Data.SqlClient;

namespace CRUDApplicationAPI.DataAccess
{
    public class DatabaseContext
    {
        private const string ConnectionString = "Data Source=DESKTOP-O95VIPJ\\SQLEXPRESS;Initial Catalog=CRUDApplication;Integrated Security=True;";
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

        public void Dispose()
        {
            if (_connection != null)
            {
                if (_connection.State != System.Data.ConnectionState.Closed)
                {
                    _connection.Close();
                }
                _connection.Dispose();
            }
        }
    }
}
