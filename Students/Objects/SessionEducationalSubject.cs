using ORM.Creators;
using System;

namespace Students.Objects
{
    public class SessionEducationalSubject : BaseModel
    {
        public SessionEducationalSubject(DateTime date, string type)
        {
            Date = date;
        }

        public SessionEducationalSubject()
        {
            EducationalSubject = new EducationalSubject();
        }

        public int EducationalSubjectId { get; set; }

        public EducationalSubject EducationalSubject { get; set; }

        public DateTime Date { get; set; }

        public int SessionId { get; set; }

        public Session Session { get; set; }

        public override string ToString() => $"\n{Session}{EducationalSubject}\t Date: {Date.ToShortDateString()}";
    }
}
