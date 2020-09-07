using ORM.Creators;
using Students;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Reflection;

namespace ORM
{
    public class Orm<T> : DBContext where T : BaseModel, new()
    {
        private static Orm<T> instance;

        public Orm(string connectionString) : base (connectionString)
        {
            Properties = new List<PropertyInfo>(typeof(T).GetProperties());
        }

        private List<PropertyInfo> Properties { get; set; }

        public static Orm<T> GetInstance(string connectionString)
        {
            if (instance == null)
            {
                instance = new Orm<T>(connectionString);
            }

            return instance;
        }

        public List<T> GetTable(string tableName)
        {
            var sqlExpression = $"SELECT * FROM {tableName}";
            var reader = new SqlCommand(sqlExpression, Connection).ExecuteReader();

            var obj = ModelFactory.CreateModel<T>();

            var collection = new List<T>();
            var typeOfT = typeof(T);

            var fieldCount = reader.FieldCount;

            if (reader.HasRows)
            {
                while (reader.Read())
                {
                    for (int i = 0; i < fieldCount; i++)
                    {
                        var fieldName = reader.GetName(i);
                        var propInfo = typeOfT.GetProperty(fieldName);
                        propInfo?.SetValue(obj, reader.GetValue(i));
                    }
                    collection.Add(obj as T);
                    obj = new T();
                }
            }

            return collection;
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
