using ORM.Interfaces;

namespace ORM.Creators
{
    public abstract class FabricBaseModel : IFabricBaseModel
    {
        public abstract BaseModel Create();
    }
}
