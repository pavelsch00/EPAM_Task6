using ORM.Creators;
using Students.Objects;

namespace Students.Creators.Objects
{
    public class SessionCreator : FabricBaseModel
    {
        public override BaseModel Create()
        {
            return new Session();
        }
    }
}
