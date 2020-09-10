using ORM.Creators;

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
