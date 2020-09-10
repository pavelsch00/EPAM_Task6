using System;
using ORM.Creators;
using Students.Interfaces;

namespace Students.Objects
{
    public class EducationalSubject : BaseModel, IEducationalSubject
    {
        public EducationalSubject()
        {
        }

        public string SubjectName { get; set; }

        public string SubjectType { get; set; }

        public override bool Equals(object obj) => obj is EducationalSubject subject &&
                   SubjectName == subject.SubjectName &&
                   SubjectType == subject.SubjectType;

        public override int GetHashCode() => HashCode.Combine(SubjectName, SubjectType);

        public override string ToString() => $"\nName: {SubjectName}\t Type:{SubjectType}";
    }
}
