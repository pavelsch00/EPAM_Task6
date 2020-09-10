using ORM.Creators;
using Students.Objects;

namespace Students.Creators.Objects
{
    public class StudentCreator : FabricBaseModel
    {
        public override BaseModel Create()
        {
            return new Student();
        }
    }
}
