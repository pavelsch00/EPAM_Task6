using System;
using ORM.Creators;
using Students.Interfaces;

namespace Students.Objects
{
    public class SessionEducationalSubject : BaseModel, ISessionEducationalSubject
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

        public override bool Equals(object obj) => obj is SessionEducationalSubject subject &&
                   EducationalSubjectId == subject.EducationalSubjectId &&
                   Date == subject.Date &&
                   SessionId == subject.SessionId;

        public override int GetHashCode() => HashCode.Combine(EducationalSubjectId, Date, SessionId);
    }
}
