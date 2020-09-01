using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
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
            var sqlExpression = $"SELECT * FROM {tableName}";
            return new SqlCommand(sqlExpression, Connection).ExecuteReader(); ;
        }

        public void Create(T obj, string table)
        {
            var sqlExpression = $"INSERT INTO {table} (";

            foreach (var property in typeof(T).GetProperties())
            {
                if (property.Name == "Id")
                {
                    continue;
                }

                sqlExpression += property.Name + ",";
            }
            sqlExpression = sqlExpression.Remove(sqlExpression.Length - 1);

            sqlExpression += ") VALUES (";

            foreach (var item in Properties)
            {
                if (item.Name == "Id")
                {
                    continue;
                }

                var propValue = item.GetValue(obj);
                sqlExpression += "'" + propValue + "',";
            }
            sqlExpression = sqlExpression.Remove(sqlExpression.Length - 1);
            sqlExpression += ");";

            var sqlCommand = new SqlCommand(sqlExpression, Connection);
            sqlCommand.ExecuteNonQuery();
        }

        public void Update(T obj, string table)
        {
            var sqlExpression = $"UPDATE {table} SET ";

            string idName = null;
            object idValue = null;

            foreach (var item in Properties)
            {
                if (item.Name == "Id")
                {
                    idName = item.Name;
                    idValue = item.GetValue(obj);
                    continue;
                }
                sqlExpression += $"[{item.Name}]='item.GetValue(obj)',";
            }
            sqlExpression = sqlExpression.Remove(sqlExpression.Length - 1);
            sqlExpression += $"WHERE [{idName}]='{idValue.ToString()}';";

            var sqlCommand = new SqlCommand(sqlExpression, Connection);
            sqlCommand.ExecuteNonQuery();
        }

        public void Delete(T obj, string table)
        {
            string sqlExpression = $"DELETE FROM {table} WHERE ";
            var property = Properties.First(item => item.Name == "Id");

            sqlExpression += $"{property.Name} ='{property.GetValue(obj)}';";

            var sqlCommand = new SqlCommand(sqlExpression, Connection);
            sqlCommand.ExecuteNonQuery();
        }
    }
}
