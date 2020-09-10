using ORM.Creators;

namespace Students.Objects
{
    public class StudentResult : BaseModel
    {
        public StudentResult(Student student, string mark, SessionEducationalSubject educationalSubject)
        {
            Student = student;

            Mark = mark;

            SessionEducationalSubject = educationalSubject;
        }

        public StudentResult()
        {
            Student = new Student();
            SessionEducationalSubject = new SessionEducationalSubject();
        }

        public Student Student { get; set; }

        public SessionEducationalSubject SessionEducationalSubject { get; set; }

        public int StudentId { get; set; }

        public int EducationalSubjectId { get; set; }

        public string Mark { get; set; }

        public override string ToString() => $"\n{Student} {SessionEducationalSubject}\t Assesment: {Mark}";
    }
}
