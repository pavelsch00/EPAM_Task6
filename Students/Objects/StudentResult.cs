using System;
using ORM.Creators;
using Students.Interfaces;

namespace Students.Objects
{
    public class StudentResult : BaseModel, IStudentResult
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

        public int SessionEducationalSubjectId { get; set; }

        public string Mark { get; set; }

        public override string ToString() => $"\n{Student} {SessionEducationalSubject}\t Assesment: {Mark}";

        public override bool Equals(object obj) => obj is StudentResult result &&
                   StudentId == result.StudentId &&
                   SessionEducationalSubjectId == result.SessionEducationalSubjectId &&
                   Mark == result.Mark;

        public override int GetHashCode() => HashCode.Combine(StudentId, SessionEducationalSubjectId, Mark);
    }
}
