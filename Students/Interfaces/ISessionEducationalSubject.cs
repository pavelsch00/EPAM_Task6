using System;
using Students.Objects;

namespace Students.Interfaces
{
    public interface ISessionEducationalSubject
    {
        public int EducationalSubjectId { get; set; }

        public EducationalSubject EducationalSubject { get; set; }

        public DateTime Date { get; set; }

        public int SessionId { get; set; }

        public Session Session { get; set; }
    }
}
