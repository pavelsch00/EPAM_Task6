﻿using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Reflection;
using ORM.Creators;

namespace ORM
{
    public class DbOrm<T> where T : BaseModel, new()
    {
        private static DbOrm<T> instance;

        private FabricBaseModel _fabricBaseModel;

        private DbOrm(string connectionString, FabricBaseModel fabricBaseModel)
        {
            Properties = new List<PropertyInfo>(typeof(T).GetProperties());
            Connection = new SqlConnection(connectionString);
            _fabricBaseModel = fabricBaseModel;
        }

        public SqlConnection Connection { get; set; }

        private List<PropertyInfo> Properties { get; set; }

        public static DbOrm<T> GetInstance(string connectionString, FabricBaseModel fabricBaseModel)
        {
            if (instance == null)
            {
                instance = new DbOrm<T>(connectionString, fabricBaseModel);
            }

            return instance;
        }

        public List<T> GetTable(string tableName)
        {
            var sqlExpression = $"SELECT * FROM {tableName}";
            var reader = new SqlCommand(sqlExpression, Connection).ExecuteReader();

            var obj = _fabricBaseModel.Create();

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
                    collection.Add((T)obj);
                    obj = _fabricBaseModel.Create();
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
