using System.Collections.Generic;

namespace ORM.Interfaces
{
    public interface ICustomDbSet<T>
    {
        public List<T> GetCollection();

        public void Add(List<T> collection);

        public void Add(T addObj);

        public void Сhange(int id, T item);

        public void Remove(int id);
    }
}
