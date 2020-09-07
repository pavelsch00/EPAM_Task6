using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using ORM;
using ORM.Creators;

namespace CRUD
{
    public class CustomDbSet<T> where T : BaseModel, new()
    {
        private readonly string _tableName;

        public CustomDbSet(string connectionString, string tableName)
        {
            Orm = DbOrm<T>.GetInstance(connectionString);
            Connection = Orm.Connection;
            Collection = new List<T>();
            _tableName = tableName;
        }

        public SqlConnection Connection { get; set; }

        public List<T> Collection { get; set; }

        private DbOrm<T> Orm { get; set; }

        public List<T> GetFromTable()
        {
            Connection.Open();
            var dataCollection = Orm.GetTable(_tableName);
            Connection.Close();

            var typeOfT = typeof(T);
            var obj = ModelFactory.CreateModel<T>();

            if(Collection.Count != 0)
            {
                Collection.Clear();
            }

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
                    Collection.Add((T)obj);
                    obj = ModelFactory.CreateModel<T>();
                }
            }

            return Collection;
        }

        public void Create(List<T> collection, string table)
        {
            if (Collection.Count == 0)
            {
                GetFromTable();
            }

            Connection.Open();

            foreach (var item in Collection)
            {
                collection = collection.Where(obj => !obj.Equals(item)).Select(item => item).ToList();
            }

            foreach (var item in collection)
            {
                Orm.Create(item, table);
            }

            Connection.Close();
        }

        public void Update(List<T> obj, string table)
        {
            if (Collection.Count == 0)
            {
                GetFromTable();
            }

            Connection.Open();

            foreach (var item in obj)
            {
                Orm.Update(item, table);
            }

            Connection.Close();
        }

        public void Dalete(List<T> obj, string table)
        {
            if (Collection.Count == 0)
            {
                GetFromTable();
            }

            Connection.Open();

            foreach (var item in obj)
            {
                Orm.Delete(item, table);
            }

            Connection.Close();
        }
    }
}
