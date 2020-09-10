using System.Collections.Generic;
using System.Data.SqlClient;
using System.Reflection;
using ORM.Creators;

namespace ORM
{
    public class WorkWithDb<T> where T : BaseModel, new()
    {
        private static WorkWithDb<T> instance;

        private readonly FabricBaseModel _fabricBaseModel;

        private readonly string _tableName;

        private readonly List<PropertyInfo> _properties;

        private WorkWithDb(string connectionString, string tableName, FabricBaseModel fabricBaseModel)
        {
            _properties = new List<PropertyInfo>(typeof(T).GetProperties());
            Connection = new SqlConnection(connectionString);
            _fabricBaseModel = fabricBaseModel;
            _tableName = tableName;
        }

        public SqlConnection Connection { get; set; }

        public static WorkWithDb<T> GetInstance(string connectionString, string tableName, FabricBaseModel fabricBaseModel)
        {
            if (instance == null)
            {
                instance = new WorkWithDb<T>(connectionString, tableName, fabricBaseModel);
            }

            return instance;
        }

        public List<T> Read()
        {
            var sqlExpressionString = $"SELECT * FROM {_tableName}";

            var sqlCommand = new SqlCommand(sqlExpressionString, Connection);
            sqlCommand.Parameters.AddWithValue(_tableName, _tableName);

            SqlDataReader reader = sqlCommand.ExecuteReader();
            var collection = new List<T>();
            var typeOfT = typeof(T);

            var fieldCount = reader.FieldCount;

            if (reader.HasRows)
            {
                while (reader.Read())
                {
                    var obj = _fabricBaseModel.Create();
                    for (int i = 0; i < fieldCount; i++)
                    {
                        var propInfo = typeOfT.GetProperty(reader.GetName(i));
                        propInfo?.SetValue(obj, reader.GetValue(i));
                    }
                    collection.Add((T)obj);
                }
            }

            return collection;
        }

        public void Create(T obj)
        {
            var sqlExpressionString = $"INSERT INTO {_tableName} (";
            var parameterName = new List<string>
            {
                _tableName
            };
            foreach (var property in _properties) /*typeof(T).GetProperties()*/
            {
                if (property.Name == "Id")
                {
                    continue;
                }

                sqlExpressionString += $"@{property.Name},";
                parameterName.Add($"@{property.Name}");
            }
            sqlExpressionString = sqlExpressionString.Remove(sqlExpressionString.Length - 1);

            sqlExpressionString += ") VALUES (";

            foreach (var item in _properties)
            {
                if (item.Name == "Id")
                {
                    continue;
                }

                var propValue = item.GetValue(obj);
                sqlExpressionString += $"'{ propValue}',";
            }
            sqlExpressionString = sqlExpressionString.Remove(sqlExpressionString.Length - 1);
            sqlExpressionString += ");";

            var sqlCommand = new SqlCommand(sqlExpressionString, Connection);
            sqlCommand.Parameters.AddWithValue(_tableName, _tableName);
            int i = 1;
            foreach (var property in _properties)
            {
                if (property.Name == "Id")
                {
                    continue;
                }

                var propValue = property.GetValue(obj);
                sqlCommand.Parameters.AddWithValue(parameterName[i], propValue);
                i++;
            }

            sqlCommand.ExecuteNonQuery();
        }

        public void Update(int id, T obj)
        {
            string sqlExpressionString = $"UPDATE {_tableName} SET ";

            foreach (var item in _properties)
            {
                sqlExpressionString += $"[{item.Name}] = @{item.Name},";
            }

            sqlExpressionString = sqlExpressionString.Remove(sqlExpressionString.Length - 1);

            sqlExpressionString += $" WHERE ID = @ID;";
            var sqlCommand = new SqlCommand(sqlExpressionString, Connection);

            foreach (var item in _properties)
            {
                sqlCommand.Parameters.AddWithValue($"@{item.Name}", item.GetValue(obj));
            }

            sqlCommand.Parameters.AddWithValue($"_tableName", _tableName);
            sqlCommand.Parameters.AddWithValue("@ID", id);
            sqlCommand.ExecuteNonQuery();
        }

        public void Delete(int id)
        {
            string sqlExpressionString = $"DELETE FROM {_tableName} WHERE ID = @ID ;";

            var sqlCommand = new SqlCommand(sqlExpressionString, Connection);
            sqlCommand.Parameters.AddWithValue($"{_tableName}", _tableName);
            sqlCommand.Parameters.AddWithValue("@ID", id);
            sqlCommand.ExecuteNonQuery();
        }
    }
}
