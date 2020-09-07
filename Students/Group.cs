using Students.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace Students
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
    }
}
