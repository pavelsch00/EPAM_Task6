using ORM.Creators;
using System;
using System.Collections.Generic;
using System.Text;

namespace Students.Objects
{
    public class EducationalSubject : BaseModel
    {
        public EducationalSubject()
        {
        }

        public string SubjectName { get; set; }

        public string SubjectType { get; set; }

        public override string ToString() => $"\nName: {SubjectName}\t Type:{SubjectType}";
    }
}
