using ORM;
using Students;
using System.Collections.Generic;
using System.Linq;

namespace CRUD
{
    public class Crud <T> : DBContext where T : BaseModel, new()
    {
        public Crud(string connectionString) : base(connectionString)
        {
            Orm = Orm<T>.GetInstance(ConnectionString);
        }

        private Orm<T> Orm { get; set; }

        public List<T> GetFromTable(string tableName)
        {
            Connection.Open();
            var dataCollection = Orm.GetTable(tableName);
            Connection.Close();
            var collection = new List<T>();
            var typeOfT = typeof(T);

            var obj = new T();

            if (dataCollection != null)
            {
                for (int i = 0; i < dataCollection.Count; i++)
                {
                    for (int j = 0; j < typeOfT.GetProperties().Count(); j++)
                    {
                        var fieldName = typeOfT.GetProperties();
                        var propInfo = typeOfT.GetProperty(fieldName[j].Name);
                        propInfo?.SetValue(obj, propInfo.GetValue(dataCollection[i]));
                    }
                    collection.Add(obj);
                    obj = new T();
                }
            }

            return collection;
        }

        public void Create(List<T> obj, string table)
        {
            Connection.Open();

            foreach (var item in obj)
            {
                Orm.Create(item, table);
            }

            Connection.Close();
        }

        public void Update(List<T> obj, string table)
        {
            Connection.Open();

            foreach (var item in obj)
            {
                Orm.Update(item, table);
            }

            Connection.Close();
        }

        public void Dalete(List<T> obj, string table)
        {
            Connection.Open();

            foreach (var item in obj)
            {
                Orm.Delete(item, table);
            }

            Connection.Close();
        }
    }
}
