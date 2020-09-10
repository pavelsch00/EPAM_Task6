using ORM.Creators;
using Students.Objects;

namespace Students.Creators.Objects
{
    public class EducationalSubjectCreator : FabricBaseModel
    {
        public override BaseModel Create()
        {
            return new EducationalSubject();
        }
    }
}
