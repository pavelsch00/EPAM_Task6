using System;
using System.Collections.Generic;
using System.Text;

namespace ORM
{
    public abstract class BaseOrm
    {
        public BaseOrm(string connectionString)
        {
            ConnectionString = connectionString;
        }

        protected string ConnectionString { get; set; }
    }
}
