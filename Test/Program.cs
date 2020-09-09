using CRUD;
using ORM;
using Students;
using Students.WorkWithCrud;
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
            string connectionString = @"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=Task6;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False";


            //CustomDbSet<Student> crudStudent = new CustomDbSet<Student>(connectionString, "Students");
            //CustomDbSet<Group> crudGroup = new CustomDbSet<Group>(connectionString, "Groups");
            var studentDBContext = new StudentDBContext(connectionString);
            //List<Group> groups = new List<Group>();
            //groups.Add(new Group("IS-11"));
            //groups.Add(new Group("IS-12"));

            var listStudents = studentDBContext.Student.GetFromTable();
            var listSessions = studentDBContext.Session.GetFromTable();
            var listGroup = studentDBContext.Group.GetFromTable();
            var listEducationSubjects = studentDBContext.EducationalSubject.GetFromTable();
            var listStudentResults = studentDBContext.StudentResult.GetFromTable();
            
            listStudents = SetRelation.BindStudentWithGroup(listStudents, listGroup);
            listSessions = SetRelation.BindSessionWithGroup(listSessions, listGroup);
            listEducationSubjects = SetRelation.BindEducationalSubjectWithSession(listEducationSubjects, listSessions);
            listStudentResults = SetRelation.BindStudentResultWithStudent(listStudentResults, listStudents, listEducationSubjects);
            
            //studentDBContext.Group.Create( groups);

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
            foreach (var item in listStudentResults)
            {
                Console.WriteLine(item);
            }
        }
    }
}
