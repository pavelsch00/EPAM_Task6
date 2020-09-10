using Students.Objects;

namespace Students.Interfaces
{
    public interface IStudentResult
    {
        public Student Student { get; set; }

        public SessionEducationalSubject SessionEducationalSubject { get; set; }

        public int StudentId { get; set; }

        public int SessionEducationalSubjectId { get; set; }

        public string Mark { get; set; }
    }
}
