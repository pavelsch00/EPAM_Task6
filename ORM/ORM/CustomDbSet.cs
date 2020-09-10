using System.Collections.Generic;
using System.Linq;
using ORM.Creators;
using ORM.Interfaces;

namespace ORM
{
    public class CustomDbSet<T> : ICustomDbSet<T> where T : BaseModel, new()
    {
        private static CustomDbSet<T> _instance;

        private readonly string _tableName;

        private readonly BasicMethodDb<T> _workWithDb;

        private CustomDbSet(string connectionString, string tableName, FabricBaseModel fabricBaseModel)
        {
            _tableName = tableName;
            _workWithDb = BasicMethodDb<T>.GetInstance(connectionString, _tableName, fabricBaseModel);
            Collection = GetCollection();
        }

        public static CustomDbSet<T> GetInstance(string connectionString, string tableName, FabricBaseModel fabricBaseModel)
        {
            if (_instance == null)
            {
                _instance = new CustomDbSet<T>(connectionString, tableName, fabricBaseModel);
            }

            return _instance;
        }

        public List<T> Collection { get; set; }

        public List<T> GetCollection()
        {
            Collection = _workWithDb.Read();

            return Collection;
        }

        public void Add(List<T> collection)
        {
            foreach (var item in Collection)
            {
                collection = collection.Where(obj => !obj.Equals(item)).Select(item => item).ToList();
            }

            foreach (var item in collection)
            {
                _workWithDb.Create(item);
            }
        }

        public void Add(T addObj)
        {
            if(addObj != Collection.Select(item => item))
            {
                _workWithDb.Create(addObj);
            }
        }

        public void Сhange(int id, T item)
        {
            _workWithDb.Update(id, item);
        }

        public void Remove(int id)
        {
            _workWithDb.Delete(id);
        }
    }
}
