using ORM;
using Students.Creators.Objects;
using Students.Objects;
using Students.WorkWithCrud;

namespace Students.WorkWithORM
{
    public class StudentDBContext : DbContext
    {
        public StudentDBContext(string connectionString) : base(connectionString)
        {
            SessionEducationalSubject = CustomDbSet<SessionEducationalSubject>.GetInstance(ConnectionString, "SessionEducationalSubjects", new SessionEducationalSubjectCreator());
            EducationalSubject = CustomDbSet<EducationalSubject>.GetInstance(ConnectionString, "EducationalSubjects", new EducationalSubjectCreator());
            Group = CustomDbSet<Group>.GetInstance(ConnectionString, "Groups", new GroupCreator());
            Session = CustomDbSet<Session>.GetInstance(ConnectionString, "Sessions", new SessionCreator());
            Student = CustomDbSet<Student>.GetInstance(ConnectionString, "Students", new StudentCreator());
            StudentResult = CustomDbSet<StudentResult>.GetInstance(ConnectionString, "StudentResults", new StudentResultCreator());

            SetRelationSheet();
        }

        public CustomDbSet<SessionEducationalSubject> SessionEducationalSubject { get; set; }

        public CustomDbSet<EducationalSubject> EducationalSubject { get; set; }

        public CustomDbSet<Group> Group { get; set; }

        public CustomDbSet<Session> Session { get; set; }

        public CustomDbSet<Student> Student { get; set; }

        public CustomDbSet<StudentResult> StudentResult { get; set; }

        private void SetRelationSheet()
        {
            Student.Collection = SetRelation.BindStudentWithGroup(Student.Collection, Group.Collection);

            Session.Collection = SetRelation.BindSessionWithGroup(Session.Collection, Group.Collection);

            SessionEducationalSubject.Collection = SetRelation.BindSessionEducationalSubjectWithSession(
                SessionEducationalSubject.Collection, Session.Collection, EducationalSubject.Collection);

            StudentResult.Collection = SetRelation.BindStudentResultWithStudent(
                StudentResult.Collection, Student.Collection, SessionEducationalSubject.Collection);
        }
    }
}
