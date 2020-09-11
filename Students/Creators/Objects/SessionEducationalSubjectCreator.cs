using ORM.Creators;
using ORM.Interfaces;
using Students.Objects;

namespace Students.Creators.Objects
{
    /// <summary>
    /// Class describes the SessionEducationalSubjectCreator.
    /// </summary>
    public class SessionEducationalSubjectCreator : FabricBaseModel, IFabricBaseModel
    {
        /// <summary>
        /// Method create SessionEducationalSubject object.
        /// </summary>
        /// <returns>SessionEducationalSubject object.</returns>
        public override BaseModel Create()
        {
            return new SessionEducationalSubject();
        }
    }
}
