using ORM.Creators;
using ORM.Interfaces;
using Students.Objects;

namespace Students.Creators.Objects
{
    /// <summary>
    /// Class describes the StudentCreator.
    /// </summary>
    public class StudentCreator : FabricBaseModel, IFabricBaseModel
    {
        /// <summary>
        /// Method create Student object.
        /// </summary>
        /// <returns>Student object.</returns>
        public override BaseModel Create()
        {
            return new Student();
        }
    }
}
