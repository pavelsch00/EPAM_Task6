using System.Collections.Generic;
using System.Data.SqlClient;
using System.Reflection;

namespace ORM
{
    public class Orm<T>
    {
        public Orm(string connectionString)
        {
            ConnectionString = connectionString;
            Connection = new SqlConnection(ConnectionString);
            Properties = new List<PropertyInfo>(typeof(T).GetProperties());
        }

        private List<PropertyInfo> Properties { get; set; }

        private string ConnectionString { get; set; }

        private SqlConnection Connection { get; set; }

        public void ConnectToBd()
        {
            Connection.Open();
        }

        public void DisConnectToBd()
        {
            Connection.Close();
        }

        public SqlDataReader GetTable(string tableName)
        {
            var sqlExpressionGetStudent = $"SELECT * FROM {tableName}";
            return new SqlCommand(sqlExpressionGetStudent, Connection).ExecuteReader(); ;
        }

        public void Create(T obj, string table)
        {
            var sqlExpressionGetStudent = $"INSERT INTO {table} (";

            foreach (var property in typeof(T).GetProperties())
            {
                if (property.Name == "Id")
                {
                    continue;
                }

                sqlExpressionGetStudent += property.Name + ",";
            }
            sqlExpressionGetStudent = sqlExpressionGetStudent.Remove(sqlExpressionGetStudent.Length - 1);

            sqlExpressionGetStudent += ") VALUES (";

            foreach (var property in Properties)
            {
                if (property.Name == "Id")
                {
                    continue;
                }
                var propValue = property.GetValue(obj);
                sqlExpressionGetStudent += "'" + propValue + "',";
            }
            sqlExpressionGetStudent = sqlExpressionGetStudent.Remove(sqlExpressionGetStudent.Length - 1);
            sqlExpressionGetStudent += ");";

            var sqlCommand = new SqlCommand(sqlExpressionGetStudent, Connection);
            sqlCommand.ExecuteNonQuery();
        }
    }
}
