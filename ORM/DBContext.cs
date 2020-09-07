using System.Data.SqlClient;

namespace ORM
{
    public abstract class DBContext
    {
        public DBContext(string connectionString)
        {
            ConnectionString = connectionString;
            Connection = new SqlConnection(ConnectionString);
        }

        public string ConnectionString { get; set; }

        public SqlConnection Connection { get; set; }
    }
}
