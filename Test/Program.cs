using CRUD;
using ORM;
using Students;
using Students.Tables;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;

namespace Test
{
    class Program
    {
        static void Main(string[] args)
        {
            string connectionString = @"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=StudentsDb;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False";


            //CustomDbSet<Student> crudStudent = new CustomDbSet<Student>(connectionString, "Students");
            //CustomDbSet<Group> crudGroup = new CustomDbSet<Group>(connectionString, "Groups");
            var studentDBContext = new StudentDBContext(connectionString);
            List<Group> groups = new List<Group>();
            groups.Add(new Group("IS-11"));
            groups.Add(new Group("IS-12"));

            var listGroups = studentDBContext.Group.GetFromTable();
            studentDBContext.Group.Create( groups, "Groups");

            /*
            crudGroup.ConnectToBd(connectionString);
            var listGroup = crudGroup.GetFromTable("Groups");
            // crudGroup.Dalete(groups, "Groups");
            // crudGroup.Update(groups, "Groups");
            crudGroup.DisConnectToBd();*/
            /*
            foreach (var item in listGroup)
            {
                Console.WriteLine(item);
            }*/

            /*
            GetFromDb orm = new GetFromDb(connectionString);

            List<Student> students = new List<Student>();
            students = orm.GetStudents();
            */
            foreach (var item in listGroups)
            {
                Console.WriteLine(item);
            }
        }
    }
}
