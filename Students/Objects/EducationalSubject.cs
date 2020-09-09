using ORM.Creators;
using System;
using System.Collections.Generic;
using System.Text;

namespace Students.Objects
{
    public class EducationalSubject : BaseModel
    {
        public EducationalSubject(string name, DateTime date, string type)
        {
            SubjectName = name;
            Date = date;
            SubjectType = type;
        }

        public EducationalSubject()
        {
        }

        public string SubjectName { get; set; }

        public DateTime Date { get; set; }

        public string SubjectType { get; set; }

        public int SessionId { get; set; }

        public Session Session { get; set; }

        public override string ToString() => $"\n{Session}Name: {SubjectName}\t Date: {Date.ToShortDateString()}\t Type:{SubjectType}";
    }
}
