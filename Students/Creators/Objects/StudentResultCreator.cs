using ORM.Creators;
using ORM.Interfaces;
using Students.Objects;

namespace Students.Creators.Objects
{
    /// <summary>
    /// Class describes the StudentResultCreator.
    /// </summary>
    public class StudentResultCreator : FabricBaseModel, IFabricBaseModel
    {
        /// <summary>
        /// Method create StudentResult object.
        /// </summary>
        /// <returns>StudentResult object.</returns>
        public override BaseModel Create()
        {
            return new StudentResult();
        }
    }
}
