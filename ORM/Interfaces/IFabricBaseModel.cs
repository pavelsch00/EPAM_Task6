using ORM.Creators;

namespace ORM.Interfaces
{
    public interface IFabricBaseModel
    {
        public abstract BaseModel Create();
    }
}
