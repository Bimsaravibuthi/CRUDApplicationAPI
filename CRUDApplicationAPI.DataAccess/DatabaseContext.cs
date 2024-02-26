using System.Data.SqlClient;

namespace CRUDApplicationAPI.DataAccess
{
    public class DatabaseContext
    {
        private const string ConnectionString = "Data Source=DESKTOP-TH5C59L\\SQLEXPRESS;" +
                                                "Initial Catalog=CRUDApplication;" +
                                                "Integrated Security=True;";
        private static SqlConnection? _connection = null;
        private static readonly object _connectionLock = new();

        private DatabaseContext() { }
        public static SqlConnection GetSqlConnection()
        {
            lock (_connectionLock)
            {
                _connection ??= new SqlConnection(ConnectionString);

                if (_connection.State != System.Data.ConnectionState.Open)
                {
                    _connection.Open();
                }
                return _connection;
            }
        }

        public static void Close()
        {
            lock ( _connectionLock)
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
}
