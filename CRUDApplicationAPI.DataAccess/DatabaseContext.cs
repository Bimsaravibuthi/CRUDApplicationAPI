using System.Data.SqlClient;

namespace CRUDApplicationAPI.DataAccess
{
    public class DatabaseContext
    {
        private const string ConnectionString = "Data Source=DESKTOP-TH5C59L\\SQLEXPRESS;Initial Catalog=CRUDApplication;Integrated Security=True;";
        private static SqlConnection? _connection = null;

        private DatabaseContext() { }
        public static SqlConnection GetSqlConnection()
        {
            if(_connection == null)
            {
                _connection = new SqlConnection(ConnectionString);
            }
            else if (_connection.State != System.Data.ConnectionState.Open)
            {
                _connection.Open();
            }
            return _connection;
        }

        public static void Dispose()
        {
            if (_connection != null)
            {
                if (_connection.State != System.Data.ConnectionState.Closed)
                {
                    _connection.Close();
                }
            }
        }
    }
}
