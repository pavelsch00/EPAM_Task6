using Students;
using System;
using System.Collections.Generic;
using System.Reflection;
using System.Text;

namespace ORM.Creators
{
    public class ModelFactory
    {
        public static BaseModel CreateModel<T>() where T : BaseModel
        {
            return Activator.CreateInstance<T>();
        }

        public static BaseModel CreateModel(string modelName)
        {
            var assembly = Assembly.GetExecutingAssembly();
            var type = assembly.GetType(modelName).FullName;
            return (BaseModel)Activator.CreateInstanceFrom(assembly.Location, type).Unwrap();
        }
    }
}
