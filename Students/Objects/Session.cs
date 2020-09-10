using System;
using ORM.Creators;
using Students.Interfaces;

namespace Students.Objects
{
    public class Session : BaseModel, ISession
    {
        public Session(int number, Group group)
        {
            SessionNumber = number;
            Group = group;
        }

        public Session(int number)
        {
            SessionNumber = number;
        }

        public Session()
        {
            Group = new Group();
        }

        public int GroupId { get; set; }

        public Group Group { get; set; }

        public int SessionNumber { get; set; }

        public override string ToString() => $"\nSession Number: {SessionNumber} {Group}";

        public override bool Equals(object obj) => obj is Session session &&
                   GroupId == session.GroupId &&
                   SessionNumber == session.SessionNumber;

        public override int GetHashCode() => HashCode.Combine(GroupId, SessionNumber);
    }
}
