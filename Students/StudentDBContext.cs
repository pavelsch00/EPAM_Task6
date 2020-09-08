using CRUD;
using Students.Tables;
using System;
using System.Collections.Generic;
using System.Text;

namespace Students
{
    public class StudentDBContext : DbContext
    {
        public StudentDBContext(string connectionString) : base(connectionString)
        {
            EducationalSubject = new CustomDbSet<EducationalSubject>(ConnectionString, "EducationalSubjects");
            Group = new CustomDbSet<Group>(ConnectionString, "Groups");
            Session = new CustomDbSet<Session>(ConnectionString, "Sessions");
            Student = new CustomDbSet<Student>(ConnectionString, "Students");
            StudentResult = new CustomDbSet<StudentResult>(ConnectionString, "StudentResults");
        }

        public CustomDbSet<EducationalSubject> EducationalSubject { get; set; }

        public CustomDbSet<Group> Group { get; set; }

        public CustomDbSet<Session> Session { get; set; }

        public CustomDbSet<Student> Student { get; set; }

        public CustomDbSet<StudentResult> StudentResult { get; set; }
    }
}
