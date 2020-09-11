using ORM.Creators;
using ORM.Interfaces;
using Students.Objects;

namespace Students.Creators.Objects
{
    /// <summary>
    /// Class describes the SessionCreator.
    /// </summary>
    public class SessionCreator : FabricBaseModel, IFabricBaseModel
    {
        /// <summary>
        /// Method create Session object.
        /// </summary>
        /// <returns>Session object.</returns>
        public override BaseModel Create()
        {
            return new Session();
        }
    }
}
