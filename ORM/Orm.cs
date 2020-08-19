using System;

namespace ORM
{
    public class Orm
    {
        public Orm(string connectionString)
        {
            ConnectionString = connectionString;
        }

        public string ConnectionString { get; set; }


    }
}
