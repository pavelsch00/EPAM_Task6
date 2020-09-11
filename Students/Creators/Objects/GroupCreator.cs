using ORM.Creators;
using ORM.Interfaces;
using Students.Objects;

namespace Students.Creators.Objects
{
    /// <summary>
    /// Class describes the GroupCreator.
    /// </summary>
    public class GroupCreator : FabricBaseModel, IFabricBaseModel
    {
        /// <summary>
        /// Method create GroupCreator object.
        /// </summary>
        /// <returns>GroupCreator object.</returns>
        public override BaseModel Create()
        {
            return new Group();
        }
    }
}
