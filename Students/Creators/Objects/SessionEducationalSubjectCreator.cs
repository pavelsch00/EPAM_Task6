using ORM.Creators;
using Students.Objects;

namespace Students.Creators.Objects
{
    public class SessionEducationalSubjectCreator : FabricBaseModel
    {
        public override BaseModel Create()
        {
            return new SessionEducationalSubject();
        }
    }
}
