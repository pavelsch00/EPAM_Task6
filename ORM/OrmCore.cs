using Students;
using System;
using System.Collections.Generic;
using System.Text;

namespace ORM
{
    public class OrmCore : BaseOrm
    {
        public OrmCore(string connectionString) : base(connectionString)
        {
            GetFromDb = new GetFromDb(ConnectionString);
        }

        private GetFromDb GetFromDb { get; set; }

        public List<Student> GetStudents() => GetFromDb.GetStudents();
    }
}
