using System;
using System.Collections.Generic;
using System.Text;

namespace ORM.Interfaces
{
    public interface IBasicMethodDb<T>
    {
        public List<T> Read();

        public void Create(T obj);

        public void Update(int id, T obj);

        public void Delete(int id);

    }
}
