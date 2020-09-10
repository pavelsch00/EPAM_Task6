using Students.Objects;

namespace Students.Interfaces
{
    public interface ISession
    {
        public int GroupId { get; set; }

        public Group Group { get; set; }

        public int SessionNumber { get; set; }
    }
}
