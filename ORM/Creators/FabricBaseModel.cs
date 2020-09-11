using ORM.Interfaces;

namespace ORM.Creators
{
    /// <summary>
    /// Class describes the fabric base model.
    /// </summary>
    public abstract class FabricBaseModel : IFabricBaseModel
    {
        /// <summary>
        /// Method read collection objects table from database.
        /// </summary>
        /// <returns>Object BaseModel.</returns>
        public abstract BaseModel Create();
    }
}
