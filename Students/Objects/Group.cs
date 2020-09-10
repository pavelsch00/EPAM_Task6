using ORM.Creators;
using Students.Interfaces;
using System;

namespace Students.Objects
{
    public class Group : BaseModel, IGroup
    {
        public Group(string name)
        {
            Name = name;
        }

        public Group(int id, string name)
        {
            Id = id;
            Name = name;
        }

        public Group()
        {

        }

        public string Name { get; set; }

        public override string ToString() => $"\nGroup Name: {Name}\t";

        public override bool Equals(object obj) => obj is Group group && Name == group.Name;

        public override int GetHashCode() => HashCode.Combine(Name);
    }
}
