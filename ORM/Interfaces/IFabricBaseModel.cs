using ORM.Creators;

namespace ORM.Interfaces
{
    /// <summary>
    /// Interface describes the fabric base model.
    /// </summary>
    public interface IFabricBaseModel
    {
        /// <summary>
        /// Method read collection objects table from database.
        /// </summary>
        /// <returns>Object BaseModel.</returns>
        public abstract BaseModel Create();
    }
}
