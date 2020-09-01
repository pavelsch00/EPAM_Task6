using ORM;
using Students;
using System;
using System.Collections.Generic;
using System.Linq;
namespace CRUD
{
    public class Crud <T> where T : new()
    {
        public Crud(string connectionString)
        {
            Orm = new Orm<T>(connectionString);
        }

        private Orm<T> Orm { get; set; }

        public void ConnectToBd() => Orm.ConnectToBd();

        public void DisConnectToBd() => Orm.DisConnectToBd();

        public List<T> GetFromTable(string tableName)
        {
            var reader = Orm.GetTable(tableName);

            var collection = new List<T>();
            var typeOfT = typeof(T);

            var obj = new T();

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
                    collection.Add(obj);
                    obj = new T();
                }
            }

            return collection;
        }

        public void Create(List<T> obj, string table)
        {
            foreach (var item in obj)
            {
                Orm.Create(item, table);
            }
        }

        public void Update(List<T> obj, string table)
        {
            foreach (var item in obj)
            {
                Orm.Update(item, table);
            }
        }

        public void Dalete(List<T> obj, string table)
        {
            foreach (var item in obj)
            {
                Orm.Delete(item, table);
            }
        }
    }
}
