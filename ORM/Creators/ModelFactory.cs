using System;

namespace ORM.Creators
{
    public class ModelFactory
    {
        public static BaseModel CreateModel<T>() where T : BaseModel => Activator.CreateInstance<T>();
    }
}
