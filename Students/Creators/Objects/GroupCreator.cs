using ORM.Creators;
using Students.Objects;

namespace Students.Creators.Objects
{
    public class GroupCreator : FabricBaseModel
    {
        public override BaseModel Create()
        {
            return new Group();
        }
    }
}
