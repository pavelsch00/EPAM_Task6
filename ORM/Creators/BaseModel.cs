using ORM.Interfaces;

namespace ORM.Creators
{
    public abstract class BaseModel : IBaseModel
    {
        public int Id { get; set; }
    }
}
