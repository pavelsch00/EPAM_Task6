using ORM.Creators;
using ORM.Interfaces;
using Students.Objects;

namespace Students.Creators.Objects
{
    public class SessionCreator : FabricBaseModel, IFabricBaseModel
    {
        public override BaseModel Create()
        {
            return new Session();
        }
    }
}
