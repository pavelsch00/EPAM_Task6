using ORM.Creators;
using ORM.Interfaces;
using Students.Objects;

namespace Students.Creators.Objects
{
    /// <summary>
    /// Class describes the EducationalSubjectCreator.
    /// </summary>
    public class EducationalSubjectCreator : FabricBaseModel, IFabricBaseModel
    {
        /// <summary>
        /// Method create EducationalSubject object.
        /// </summary>
        /// <returns>EducationalSubject object.</returns>
        public override BaseModel Create()
        {
            return new EducationalSubject();
        }
    }
}
