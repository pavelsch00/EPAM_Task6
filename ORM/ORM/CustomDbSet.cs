﻿using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using ORM.Creators;

namespace ORM
{
    public class CustomDbSet<T> where T : BaseModel, new()
    {
        private readonly string _tableName;

        private readonly SqlConnection _connection;

        private static CustomDbSet<T> _instance;

        private WorkWithDb<T> _workWithDb;

        private CustomDbSet(string connectionString, string tableName, FabricBaseModel fabricBaseModel)
        {
            _tableName = tableName;
            _workWithDb = WorkWithDb<T>.GetInstance(connectionString, _tableName, fabricBaseModel);
            _connection = _workWithDb.Connection;
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
            _connection.Open();
            Collection = _workWithDb.Read();
            _connection.Close();

            return Collection;
        }

        public void Add(List<T> collection)
        {
            _connection.Open();

            foreach (var item in Collection)
            {
                collection = collection.Where(obj => !obj.Equals(item)).Select(item => item).ToList();
            }

            foreach (var item in collection)
            {
                _workWithDb.Create(item);
            }

            _connection.Close();
        }

        public void Сhange(List<T> obj)
        {
            foreach (var item in obj)
            {
                _workWithDb.Update(item);
            }

            _connection.Close();
        }

        public void Remove(List<T> obj)
        {
            _connection.Open();

            foreach (var item in obj)
            {
                _workWithDb.Delete(item);
            }

            _connection.Close();
        }
    }
}
