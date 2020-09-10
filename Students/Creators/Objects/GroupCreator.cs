using ORM.Creators;
using ORM.Interfaces;
using Students.Objects;

namespace Students.Creators.Objects
{
    public class GroupCreator : FabricBaseModel, IFabricBaseModel
    {
        public override BaseModel Create()
        {
            return new Group();
        }
    }
}
