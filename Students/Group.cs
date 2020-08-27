using Students.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace Students
{
    public class Group : IGroup
    {
        public Group(string name)
        {
            Name = name;
        }

        public Group()
        {

        }

        public int Id { get; set; }

        public string Name { get; set; }

        public override string ToString() => $"\nGroup Name: {Name}\t";
    }
}
