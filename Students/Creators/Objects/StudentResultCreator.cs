using ORM.Creators;
using Students.Objects;

namespace Students.Creators.Objects
{
    public class StudentResultCreator : FabricBaseModel
    {
        public override BaseModel Create()
        {
            return new StudentResult();
        }
    }
}
