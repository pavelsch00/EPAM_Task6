using CRUD;
using Students.Creators.Objects;
using Students.Objects;
using System;
using System.Collections.Generic;
using System.Text;

namespace Students
{
    public class StudentDBContext : DbContext
    {
        public StudentDBContext(string connectionString) : base(connectionString)
        {
            SessionEducationalSubject = new CustomDbSet<SessionEducationalSubject>(ConnectionString, "SessionEducationalSubjects", new SessionEducationalSubjectCreator());
            EducationalSubject = new CustomDbSet<EducationalSubject>(ConnectionString, "EducationalSubjects", new EducationalSubjectCreator());
            Group = new CustomDbSet<Group>(ConnectionString, "Groups", new GroupCreator());
            Session = new CustomDbSet<Session>(ConnectionString, "Sessions", new SessionCreator());
            Student = new CustomDbSet<Student>(ConnectionString, "Students", new StudentCreator());
            StudentResult = new CustomDbSet<StudentResult>(ConnectionString, "StudentResults", new StudentResultCreator());
        }

        public CustomDbSet<SessionEducationalSubject> SessionEducationalSubject { get; set; }

        public CustomDbSet<EducationalSubject> EducationalSubject { get; set; }

        public CustomDbSet<Group> Group { get; set; }

        public CustomDbSet<Session> Session { get; set; }

        public CustomDbSet<Student> Student { get; set; }

        public CustomDbSet<StudentResult> StudentResult { get; set; }
    }
}
